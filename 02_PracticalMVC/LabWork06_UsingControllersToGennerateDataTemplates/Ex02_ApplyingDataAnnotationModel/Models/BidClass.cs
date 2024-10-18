using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace Ex01_CreatingAppWithDataStorageImpl.Models
{
    public class BidClass
    {
        // ID заявки
        public virtual int BidClassId { get; set; }
        
        // Имя заявителя
        [DisplayName("Имя заявителя")]
        public virtual string Name { get; set; }

        // Название кредита
        [DisplayName("Название кредита")]        
        public virtual string CreditHead { get; set; }

        // Дата подачи заявки
        [DisplayName("Дата подачи заявки")]
        public virtual DateTime bidDate { get; set; }
    }
}
