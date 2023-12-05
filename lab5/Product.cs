interface ISearchable<T>
{
    List<T> Search(Func<T, bool> criteria);
}

// Interface for orderable items
interface IOrderable
{
    double CalculateTotal();
}

// Class representing a Product
class Product : IOrderable
{
    public string Name { get; private set; }
    public double Price { get; private set; }
    public string Description { get; private set; }
    public string Category { get; private set; }
    public int Rating { get; private set; }

    public Product(string name, double price, string description, string category, int rating)
    {
        Name = name;
        Price = price;
        Description = description;
        Category = category;
        Rating = rating;
    }

    public double CalculateTotal()
    {
        return Price;
    }
}

// Class representing a User
class User
{
    public string Username { get; private set; }
    private string Password { get; set; }
    public List<Product> PurchaseHistory { get; private set; } = new List<Product>();

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}

// Class representing an Order
class Order : IOrderable
{
    public List<IOrderable> Items { get; private set; } = new List<IOrderable>();
    public string Status { get; private set; } = "Pending";

    public double CalculateTotal()
    {
        return Items.Sum(item => item.CalculateTotal());
    }

    public void AddItem(IOrderable item)
    {
        Items.Add(item);
    }

    public void CompleteOrder()
    {
        Status = "Completed";
    }
}

// Class representing a ShoppingCart
class ShoppingCart : Order
{
    public void Checkout(User user)
    {
        Console.WriteLine($"Checking out for user: {user.Username}");
        foreach (var item in Items)
        {
            if (item is Product product)
            {
                user.PurchaseHistory.Add(product);
            }
        }

        CompleteOrder();
    }
}

// Class representing a Store
class Store : ISearchable<Product>
{
    private List<Product> products = new List<Product>();

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public List<Product> Search(Func<Product, bool> criteria)
    {
        return products.Where(criteria).ToList();
    }
}


