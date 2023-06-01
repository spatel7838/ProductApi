using ProductInfo.API.Models;

namespace ProductInfo.API
{
    public class ProductsDataStore
    {
        public List<ProductDto> Cities { get; set; }
        public static ProductsDataStore Current {get;}=new ProductsDataStore();
        public ProductsDataStore()
        {
            // init dummy data
            Cities = new List<ProductDto>()
            {
                new ProductDto()
                {
                     Id = 1,
                     Name = "BigMac",
                     Price=30
                   
                },
                new ProductDto()
                {
                    Id = 2,
                    Name = "Fries",
                    Price=50
                },
                new ProductDto()
                {
                    Id= 3,
                    Name = "Fries",
                    Price=60
                    
                }
            };

        }

    }
}
