using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationCore.Pages
{
    public class RazorTestModel : PageModel
    {
        List<Person> people;
        public List<Person> DisplayedPeople { get; set; }

        public RazorTestModel()
        {
            people = new List<Person>()
            {
                new Person{ Name="Tomo", Age=23},
                new Person {Name = "Sam", Age=25},
                new Person {Name="Bob", Age=23},
                new Person{Name="Tomo", Age=25}
            };
        }

        public void OnGet()
        {
            DisplayedPeople = people;
        }
        // /?handler=ByName&name=Tomo
        public void OnGetByName(string name)
        {
            DisplayedPeople = people.Where(p => p.Name.Contains(name)).ToList();
        }
        public void OnGetByAge(int age)
        {
            DisplayedPeople = people.Where(p => p.Age == age).ToList();
        }

        public void OnPostGreaterThan(int age)
        {
            DisplayedPeople = people.Where(p => p.Age > age).ToList();
        }
        public void OnPostLessThan(int age)
        {
            DisplayedPeople = people.Where(p => p.Age < age).ToList();
        }

    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}