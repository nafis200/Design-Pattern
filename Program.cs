using System;
using System.Collections.Generic;

public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public bool IsAvailable { get; set; }
    public int Stack { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public IList<string> Tags { get; set; }

    public Product Clone()
    {
        return (Product)this.MemberwiseClone();
    }
}

public interface IproductService
{
    IList<Product> CopyProduct(IList<Product> products);
    void ShowProduct(Product product);
}

public class ProductService : IproductService
{
    public IList<Product> CopyProduct(IList<Product> products)
    {
        IList<Product> productsCopy = new List<Product>();

        foreach (Product product in products)
        {
            Product productCopy = product.Clone();

            productCopy.Id = Guid.NewGuid().ToString();

            productsCopy.Add(productCopy);
        }

        return productsCopy;
    }

    public void ShowProduct(Product product)
    {
        Console.WriteLine($"Id: {product.Id}");
        Console.WriteLine($"Name: {product.Name}");
        Console.WriteLine($"Price: {product.Price}");
        Console.WriteLine($"Category: {product.Category}");
        Console.WriteLine($"Stock: {product.Stack}");
        Console.WriteLine("------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IList<Product> products = new List<Product>()
        {
            new Product()
            {
                Id = "1",
                Name = "Laptop",
                Price = 1000,
                Category = "Electronics",
                Stack = 5,
                Tags = new List<string>{"Tech","Device"}
            },
            new Product()
            {
                Id = "2",
                Name = "Phone",
                Price = 500,
                Category = "Electronics",
                Stack = 10,
                Tags = new List<string>{"Mobile","Tech"}
            },
            new Product()
            {
                Id = "3",
                Name = "Headphone",
                Price = 150,
                Category = "Accessories",
                Stack = 20,
                Tags = new List<string>{"Audio","Music"}
            }
        };

        IproductService productService = new ProductService();

        IList<Product>productsCopy = productService.CopyProduct(products);

        foreach (Product item in productsCopy)
        {
            productService.ShowProduct(item);
        }
    }
}