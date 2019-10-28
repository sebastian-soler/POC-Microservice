using System;
using System.Collections.Generic;
using System.Linq;
using MSCars.Business.Interfaces;
using MSCars.Model;
using MSCars.Repository.Interfaces;

namespace MSCars.Business
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        private readonly ICategoryRepository _categoryRepository;

        public CarService(ICarRepository carRepository, ICategoryRepository categoryRepository)
        {
            _carRepository = carRepository;
            _categoryRepository = categoryRepository;
        }

        public void Add(Car entity)
        {
            if (entity == null || entity.Id != 0) throw new Exception("El Automovil no puede ser nulo.");

            if (string.IsNullOrEmpty(entity.Enrollment) || string.IsNullOrEmpty(entity.Mark) || string.IsNullOrEmpty(entity.Model))
                throw new Exception("Valide que los datos del vehiculo se encuentren correctamente completos.");

            if (_categoryRepository.Get(entity.CategoryId) == null) throw new Exception("La Categoría del vehiculo es invalida.");

            _carRepository.Add(entity);
        }

        public Car Get(int entityId)
        {
            var car = _carRepository.Get(entityId);

            if (car == null) throw new Exception("El vehiculo que intenta obtener no se encuentra registrado.");

            return car;
        }

        public IEnumerable<Car> GetAll()
        {
            return _carRepository.GetAll().ToList();
        }

        public void Remove(int entityId)
        {
            _carRepository.Remove(entityId);
        }

        public void Update(Car entity)
        {
            if (entity.Id == 0) throw new Exception("El vehiculo a actualizar es invalido.");

            _carRepository.Update(entity);
        }
    }
}
