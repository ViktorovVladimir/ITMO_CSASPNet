namespace Ex02_ModelViewControllerInteractionMVCPattern.Models
{
    public class PersonClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString() => FirstName + " " + LastName;

    }
}
