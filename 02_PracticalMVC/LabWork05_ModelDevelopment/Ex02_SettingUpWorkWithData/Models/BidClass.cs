namespace Ex02_SettingUpWorkWithData.Models
{
    public class BidClass
    {
        // ID заявки
        public virtual int BidClassId { get; set; }
        // Имя заявителя
        public virtual string Name { get; set; }
        // Название кредита
        public virtual string CreditHead { get; set; }
        // Дата подачи заявки
        public virtual DateTime bidDate { get; set; }
    }
}
