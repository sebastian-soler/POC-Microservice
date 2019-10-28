using System.Collections.Generic;
using MSRents.Model;

namespace MSRents.Business
{
    public interface IRentalService
    {
        void Add(Rental rental);

        void Remove(int rentalId);

        void Update(Rental rental);

        IEnumerable<Rental> GetAll();

        Rental Get(int customerId);
    }
}
