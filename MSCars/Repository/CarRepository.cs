using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSCars.DBContexts;
using MSCars.Model;
using MSCars.Repository.Interfaces;

namespace MSCars.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarContext _dbContext;

        public CarRepository(CarContext dbContext) => _dbContext = dbContext;

        public void Add(Car entity)
        {
            _dbContext.Add(entity);
            Save();
        }

        public void Remove(int entityId)
        {
            var car = _dbContext.Cars.Find(entityId);

            if(car != null)
            {
                using (var scope = new System.Transactions.TransactionScope())
                {
                    _dbContext.Entry(car).Entity.IsDeleted = true;

                    //car.IsDeleted = true;
                    //_dbContext.Update(car);
                    Save();

                    scope.Complete();
                }
            }
        }

        public void Update(Car entity)
        {
            var car = _dbContext.Cars.Find(entity.Id);

            if (car != null)
            {
                _dbContext.Entry(car).CurrentValues.SetValues(entity);

                //_dbContext.Entry(entity).State = EntityState.Modified;
                Save();
            }
        }

        public IEnumerable<Car> GetAll()
        {
            return _dbContext.Cars.Where(x => !x.IsDeleted).Include(x => x.Category).ToList();
        }

        public Car Get(int entityId)
        {
            return _dbContext.Cars.Include(x => x.Category).SingleOrDefault(c => c.Id == entityId && !c.IsDeleted);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
