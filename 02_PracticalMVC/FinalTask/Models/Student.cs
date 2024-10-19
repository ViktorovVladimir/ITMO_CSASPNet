using Microsoft.AspNetCore.Components.Forms;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinalTask.Models
{
    public class Student
    {
        // Student ID
        public virtual int StudentId { get; set; }

        // Student's name
        public virtual string Name { get; set; }

        // Student's year of birth
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Date of Birthday")]
        [DataType(DataType.Date)]
        public virtual DateTime BirthDate  { get; set; }

        // Study group number
        public virtual string GroupNumber  { get; set; }
    }
}
