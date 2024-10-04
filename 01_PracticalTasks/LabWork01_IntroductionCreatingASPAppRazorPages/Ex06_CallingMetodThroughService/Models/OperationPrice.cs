namespace Ex06_CallingMetodThroughService.Models
{   
    //--.
    public class OperationPrice
    {
        
        //--.
        public decimal? CalcPrice( decimal? price )
        {
            return price * (decimal?)0.18;
        }

        //--.
        public decimal? CalcPriceDiscount(decimal? price, double discont)
        {
            return price * (decimal?)discont / (decimal?)100.0;
        }

        //--.
        public decimal? CalcPriceFix()
        {
            return (decimal?)7.0;
        }



    }
}
