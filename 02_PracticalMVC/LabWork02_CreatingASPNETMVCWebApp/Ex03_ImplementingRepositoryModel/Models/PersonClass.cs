namespace Ex03_ImplementingRepositoryModel.Models
{
    public class PersonClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString() => FirstName + " " + LastName;

    }
}
