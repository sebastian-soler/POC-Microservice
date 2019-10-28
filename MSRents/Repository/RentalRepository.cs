using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSRents.DbContexts;
using MSRents.Model;

namespace MSRents.Repository
{
    public class RentalRepository : IRentalRepository
    {
        private readonly RentalContext _dbContext;

        public RentalRepository(RentalContext dbContext) => _dbContext = dbContext;

        public void Add(Rental rental)
        {
            _dbContext.Add(rental);
            Save();
        }

        public Rental Get(int rentalId)
        {
            return _dbContext.Rentals.SingleOrDefault(x => x.Id == rentalId && !x.IsDeleted);
        }

        public IEnumerable<Rental> GetAll()
        {
            return _dbContext.Rentals.ToList();
        }

        public IEnumerable<Rental> GetByCar(int carId)
        {
            return _dbContext.Rentals.Where(x => x.Id == carId && !x.IsDeleted)
                                     .Include(x => x.Car)
                                     .Include(x => x.Customer)
                                     .ToList();
        }

        public IEnumerable<Rental> GetByCustomer(int customerId)
        {
            return _dbContext.Rentals.Where(x => x.Id == customerId && !x.IsDeleted)
                                     .Include(x => x.Customer)
                                     .Include(x => x.Car)
                                     .ToList();
        }

        public void Remove(int rentalId)
        {
            var rental = _dbContext.Rentals.Find(rentalId);

            if (rental != null)
            {
                using (var scope = new System.Transactions.TransactionScope())
                {
                    _dbContext.Entry(rental).Entity.IsDeleted = true;
                    Save();

                    scope.Complete();
                }
            }
        }

        public void Update(Rental rental)
        {
            var rentalExist = _dbContext.Rentals.Find(rental.Id);

            if (rentalExist != null)
            {
                _dbContext.Entry(rentalExist).CurrentValues.SetValues(rental);

                Save();
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
