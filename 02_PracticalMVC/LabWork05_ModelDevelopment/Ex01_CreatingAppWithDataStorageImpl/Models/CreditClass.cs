namespace Ex01_CreatingAppWithDataStorageImpl.Models
{
    public class CreditClass
    {
        // ID кредита
        public virtual int CreditClassId { get; set; }
        // Название
        public virtual string Head { get; set; }
        // Период, на который выдается кредит
        public virtual int Period { get; set; }
        // Максимальная сумма кредита
        public virtual int Sum { get; set; }
        // Процентная ставка
        public virtual int Procent { get; set; }
    }
}
