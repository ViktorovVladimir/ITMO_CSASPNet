using Ex06_CallingMetodThroughService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex06_CallingMetodThroughService.Pages
{
    public class ProductIndModel : PageModel
    {

        private readonly OperationPrice _servicePrice;
        
        //--.
        public ProductClass Product { get; set; }
        public string? MessageRezult { get; private set; }

        //--.
        public ProductIndModel(OperationPrice servicePrice)
        {
            _servicePrice = servicePrice;
        }

        //--. Called when the user specifies a page in the URL address field
        public void OnGet()
        {
            //--.
            MessageRezult = "You can define a discount for a product";
        }

        //--. Called when the user clicks on buttons on the page
        public void OnPost(string name, decimal? price)
        {
            //--.
            Product = new ProductClass();

            //--.
            if( price == null || price < 0 || string.IsNullOrEmpty(name) ) 
            {
                MessageRezult = "Incorrect data transmitted. Please re-enter";

                return;
            }

            
            //--.
            //var result = price * (decimal?)0.18;
            var result = _servicePrice.CalcPrice(price);
            
            MessageRezult = $"For product {name} with price {price} will be a discount {result}";
            //--.
            Product.Price = price;
            Product.Name = name;
            
        }

        //--. Called when the user clicks on buttons on the page with name "Discontt"
        public void OnPostDiscontt( string name, decimal? price, double discont ) 
        {
            //--.
            Product = new ProductClass();
            //--.
            //var result = price * (decimal?)discont / 100;
            var result = _servicePrice.CalcPriceDiscount( price, discont );

            //--.
            MessageRezult = $"For product {name} with price {price} will be a discount {result}";
            //--.
            Product.Price = price;
            Product.Name = name;
        }

        //--. Called when the user clicks on buttons on the page with name "FixPrice"
        public void OnPostFixPrice(string name, decimal? price, double discont)
        {
            //--.
            Product = new ProductClass();


            //var result = price * (decimal?)discont / 100;
            //var result = 7;
            var result = _servicePrice.CalcPriceFix(); 

            //--.
            MessageRezult = $"For product {name} with price {price} fix price {result} USDT";
            //--.
            Product.Price = price;
            Product.Name = name;
        }
        
    }
}
