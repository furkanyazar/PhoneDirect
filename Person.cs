namespace PhoneDirect
{
    public class Person
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = Functions.ToTitleCase(value); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = Functions.ToTitleCase(value); }
        }

        public string PhoneNumber { get; set; }
    }
}
