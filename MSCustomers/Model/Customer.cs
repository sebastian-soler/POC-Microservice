namespace MSCustomers.Model
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DNI { get;  set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
