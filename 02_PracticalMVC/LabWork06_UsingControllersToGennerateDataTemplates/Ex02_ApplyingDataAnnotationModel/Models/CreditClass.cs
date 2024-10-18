using System.ComponentModel;

namespace Ex01_CreatingAppWithDataStorageImpl.Models
{
    public class CreditClass
    {
        // ID кредита
        public virtual int CreditClassId { get; set; }

        // Название
        [DisplayName("Название")]
        public virtual string Head { get; set; }

        // Период, на который выдается кредит
        [DisplayName("Период выдачи")]
        public virtual int Period { get; set; }

        // Максимальная сумма кредита
        [DisplayName("Сумма кредита")]
        public virtual int Sum { get; set; }

        // Процентная ставка
        [DisplayName("Процентная ставка")]
        public virtual int Procent { get; set; }
    }
}
