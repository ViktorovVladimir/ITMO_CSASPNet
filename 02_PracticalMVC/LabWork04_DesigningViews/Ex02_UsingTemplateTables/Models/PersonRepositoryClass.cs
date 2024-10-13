namespace Ex02_UsingTemplateTables.Models
{
    public class PersonRepositoryClass
    {
        private List<PersonClass> persons = new List<PersonClass>();

        //--.
        public int NumberOfPerson
        {
            get
            {
                return persons.Count();
            }
        }

        //--.
        public IEnumerable<PersonClass> GetAllResponses
        {
            get
            {
                return persons;
            }
        }

        //--.
        public void AddResponse( PersonClass pers )
        {
            persons.Add( pers );
        }
    }
}
