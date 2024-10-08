using Ex03_CreatingFormToFillOutData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ex03_CreatingFormToFillOutData.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public ProductClass Product { get; set; }
        public bool IsCorrect { get; set; } = true;

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
            if( price == null || price < 0 || string.IsNullOrEmpty(name)  )
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
