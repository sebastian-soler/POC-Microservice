using MSCars.Model.Base;

namespace MSCars.Model
{
    public class Car : BaseEntity
    {
        public string Enrollment { get; set; }

        public string Model { get; set; }

        public string Mark { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
