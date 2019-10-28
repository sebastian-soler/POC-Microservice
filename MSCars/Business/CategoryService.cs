using System;
using System.Collections.Generic;
using System.Linq;
using MSCars.Business.Interfaces;
using MSCars.Model;
using MSCars.Repository.Interfaces;

namespace MSCars.Business
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

        public void Add(Category entity)
        {
            if (entity == null || entity.Id != 0) throw new Exception("La categoría no puede ser nula.");

            if (string.IsNullOrEmpty(entity.Name)) throw new Exception("Valide que el nombre de la Categoria se encuentre cargado.");

            if (_categoryRepository.GetAll().Any(x => x.Name.Equals(entity.Name, StringComparison.OrdinalIgnoreCase))) throw new Exception("La Categoría del vehiculo es invalida.");

            _categoryRepository.Add(entity);
        }

        public Category Get(int entityId)
        {
            var category = _categoryRepository.Get(entityId);

            if (category == null) throw new Exception("La categoria que intenta obtener no se encuentra registrada.");

            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll().ToList();
        }

        public void Remove(int entityId)
        {
            _categoryRepository.Remove(entityId);
        }

        public void Update(Category entity)
        {
            if (entity.Id == 0) throw new Exception("La categoría a actualizar es invalida.");

            _categoryRepository.Update(entity);
        }
    }
}
