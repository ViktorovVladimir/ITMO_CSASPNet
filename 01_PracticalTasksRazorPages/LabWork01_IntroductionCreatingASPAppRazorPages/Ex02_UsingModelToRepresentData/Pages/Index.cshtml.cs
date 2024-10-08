using Ex02_UsingModelToRepresentData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ex02_UsingModelToRepresentData.Pages
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

        //--.
        public void OnGet(string name, decimal? price)
        {
            Product = new ProductClass();
            
            if( price == null || price < 0 || string.IsNullOrEmpty(name) )
            {
                IsCorrect = false; 
                return;
            }
            //--.
            Product.Price = price;
            Product.Name = name;
        }   
    }
}
