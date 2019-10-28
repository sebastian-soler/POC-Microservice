using System.Collections.Generic;
using System.Linq;
using MSCars.DBContexts;
using MSCars.Model;
using MSCars.Repository.Interfaces;

namespace MSCars.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CarContext _dbContext;

        public CategoryRepository(CarContext dbContext) => _dbContext = dbContext;

        public void Add(Category entity)
        {
            _dbContext.Add(entity);
            Save();
        }

        public void Remove(int entityId)
        {
            var category = _dbContext.Categories.Find(entityId);

            if (category != null)
            {
                using (var scope = new System.Transactions.TransactionScope())
                {
                    _dbContext.Entry(category).Entity.IsDeleted = true;

                    //category.IsDeleted = true;
                    //_dbContext.Update(category);
                    Save();

                    scope.Complete();
                }
            }
        }

        public void Update(Category entity)
        {
            var category = _dbContext.Categories.Find(entity.Id);

            if (category != null)
            {
                _dbContext.Entry(category).CurrentValues.SetValues(entity);

                //_dbContext.Entry(entity).State = EntityState.Modified;
                Save();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories.Where(x => !x.IsDeleted).ToList();
        }

        public Category Get(int entityId)
        {
            return _dbContext.Categories.SingleOrDefault(c => c.Id == entityId && !c.IsDeleted);
        }

        public void Save() => _dbContext.SaveChanges();
    }
}
