using System.Collections.Generic;
using MSRents.Model;

namespace MSRents.Repository
{
    public interface IRentalRepository
    {
        void Add(Rental rental);

        void Remove(int rentalId);

        void Update(Rental rental);

        IEnumerable<Rental> GetAll();

        Rental Get(int rentalId);

        IEnumerable<Rental> GetByCustomer(int customerId);

        IEnumerable<Rental> GetByCar(int carId);

        void Save();
    }
}
