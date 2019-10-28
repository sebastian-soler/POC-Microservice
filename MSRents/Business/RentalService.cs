using System;
using System.Collections.Generic;
using System.Linq;
using MSRents.Model;
using MSRents.Repository;

namespace MSRents.Business
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository) => _rentalRepository = rentalRepository;

        public void Add(Rental rental)
        {
            if (rental == null || rental.Id != 0) throw new Exception("El alquiler no puede ser nulo.");

            ValidateRentalDates(rental);

            _rentalRepository.Add(rental);
        }

        public Rental Get(int rentalId)
        {
            var rental = _rentalRepository.Get(rentalId);

            if (rental == null) throw new Exception("El alquiler que intenta obtener no se encuentra registrado.");

            return rental;
        }

        public IEnumerable<Rental> GetAll()
        {
            return _rentalRepository.GetAll();
        }

        public void Remove(int rentalId)
        {
            _rentalRepository.Remove(rentalId);
        }

        public void Update(Rental rental)
        {
            if (rental.Id == 0) throw new Exception("El registro que intenta actualizar es invalido.");

            ValidateRentalDates(rental);

            _rentalRepository.Update(rental);
        }

        private void ValidateRentalDates(Rental rental)
        {
            if (rental.InitialDay < rental.FinalDay) throw new Exception("La fechas son incorrectas.");

            if (rental.InitialDay < DateTime.Now.Date) throw new Exception("La fecha de inicio es incorrecta.");

            if (rental.FinalDay < DateTime.Now.Date) throw new Exception("La fecha de finalizacion es incorrecta.");

            if(rental.CarId == 0) throw new Exception("El codigo del vehiculo es incorrecto.");

            if(_rentalRepository.GetByCar(rental.CarId).Any(x => x.FinalDay > rental.InitialDay && x.InitialDay < rental.FinalDay))
                throw new Exception("El vechiculo ya se encuentra reservado en dichas fechas.");
        }
    }
}
