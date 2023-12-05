class Program
{
    static void Main()
    {
        // Create a store
        Store myStore = new Store();

        // Add products to the store
        myStore.AddProduct(new Product("Laptop", 1000, "Powerful laptop", "Electronics", 4));
        myStore.AddProduct(new Product("Book", 20, "Interesting book", "Books", 5));
        myStore.AddProduct(new Product("Coffee Maker", 50, "Automatic coffee maker", "Appliances", 4));

        // Create a user
        User john = new User("JohnDoe", "password");

        // Create a shopping cart
        ShoppingCart shoppingCart = new ShoppingCart();

        // Simulate user adding items to the shopping cart
        List<Product> laptops = myStore.Search(p => p.Name == "Laptop");
        if (laptops.Any())
        {
            shoppingCart.AddItem(laptops.First());
        }

        List<Product> books = myStore.Search(p => p.Name == "Book");
        if (books.Any())
        {
            shoppingCart.AddItem(books.First());
        }

        // Simulate user checking out
        shoppingCart.Checkout(john);

        // Display user purchase history
        Console.WriteLine($"\nPurchase History for {john.Username}:");
        foreach (var item in john.PurchaseHistory)
        {
            Console.WriteLine($"{item.Name} - Price: {item.Price}");
        }

        Console.ReadLine(); // Pause to see the output
    }
}


