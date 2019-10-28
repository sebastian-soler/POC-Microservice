using System;
using MSCars.Model;
using MSCustomers.Model;

namespace MSRents.Model
{
    public class Rental
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int CarId { get; set; }

        public float Price { get; set; }

        public DateTime InitialDay { get; set; } = DateTime.Now;

        public DateTime FinalDay { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual Customer Customer { get; set; }

        public virtual Car Car { get; set; }
    }
}
