using System;
using AutoMapper;

namespace MSRents.Model
{
    public class RentalDto
    {
        public int CarId { get; set; }

        public int CustomerId { get; set; }

        public DateTime InitialDay { get; set; }

        public DateTime FinalDay { get; set; }

        public float Price { get; set; }

        public bool IsDeleted { get; set; }

        public Rental ToEntity()
        {
            var rental = new Rental();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<RentalDto, Rental>(); });
            IMapper iMapper = config.CreateMapper();

            rental = iMapper.Map<RentalDto, Rental>(this);

            return rental;
        }
    }
}
