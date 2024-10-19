using System.ComponentModel.DataAnnotations;

namespace FinalTask.Models
{
    public class ReportCard
    {
        //--. ID report card with grade
        public virtual int ReportCardId { get; set; }

        //--. Student's name
        public virtual string Name { get; set; }

        //--. Name of discipline
        public virtual string DisciplineHead { get; set; }

        // Discipline grade
        public virtual int grade { get; set; }


        // Exam date
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        [Display(Name = "Exam date")]
        [DataType(DataType.Date)]
        public virtual DateTime dueDate { get; set; }
    }
}
