using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAppCoreRaxorPages01.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Поле не должно быть пустым")]
        [StringLength(10)]
        [Display(Name = "Имя")]
        public string? Name { get; set; }
        
        [Required]
        [Range(0, 101, ErrorMessage = "Вне разрешенного диапазона")]
        [Display(Name = "Возраст")]
        public int Age { get; set; } 
    }
}
