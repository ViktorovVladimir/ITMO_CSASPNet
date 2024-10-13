namespace Ex02_UsingTemplateTables.Models
{
    public class ModelClass
    {   
        //--.
        public static string ModelHello()
        {   
            int hour = DateTime.Now.Hour;
            string sGreeting = hour < 12 ? "Good morning" : "Good afternoon";
            
            return sGreeting;
        }   
    }   
}
