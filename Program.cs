

public class Product
{
    public string Id{get;set;}
    public string Name{get;set;}
    public string Price{get;set;}
    public string Category{get;set;}
    public string Description{get;set;}
    public bool IsAvailable{get;set;}
    public int Stack{get;set;}
    public DateTime CreatedDate{get;set;}
    public DateTime UpdatedDate{get;set;}
    public string CreatedBy{get;set;}
    public string UpdatedBy{get;set;}
    public IList<string>Tags{get;set;}
}

class Program
{
    static void Main(string[] args)
    {
       
    }
}