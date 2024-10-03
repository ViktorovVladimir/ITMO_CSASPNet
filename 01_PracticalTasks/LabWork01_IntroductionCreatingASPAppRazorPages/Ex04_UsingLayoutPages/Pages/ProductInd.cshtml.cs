using Ex04_UsingLayoutPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex04_UsingLayoutPages.Pages
{
    public class ProductIndModel : PageModel
    {
        //--.
        public ProductClass Product { get; set; }

        public string? MessageRezult { get; private set; }



        //--.
        public void OnGet()
        {
            //--.
            MessageRezult = "You can define a discount for a product";
        }

        //--.
        public void OnPost(string name, decimal? price)
        {
            Product = new ProductClass();

            //--.
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "Incorrect data transmitted. Please re-enter";

                return;
            }

            //--.
            var result = price * (decimal?)0.18;
            MessageRezult = $"For product {name} with price {price} will be a discount {result}";
            //--.
            Product.Price = price;
            Product.Name = name;

        }
    }
}
