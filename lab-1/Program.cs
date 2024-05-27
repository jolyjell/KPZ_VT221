using System;

public class Money
{
    private int notes;
    private int coins;

    public Money(int notes = 0, int coins = 0)
    {
        this.WholePart = notes;
        this.FractionPart = coins;
    }

    public int WholePart
    {
        get { return notes; }
        set { notes = value; }
    }

    public int FractionPart
    {
        get { return coins; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Копійки не можуть становити від'ємну суму");
            }
            notes += value / 100;
            coins = value % 100;
        }
    }

    public void Display()
    {
        Console.WriteLine($"{notes}.{coins:D2}");
    }

    public void Decrease(int amountNotes, int amountCoins)
    {
        int totalCoins = (notes * 100 + coins) - (amountNotes * 100 + amountCoins);
        if (totalCoins < 0)
        {
            throw new ArgumentOutOfRangeException("Зменшення перевищує поточну суму");
        }
        notes = totalCoins / 100;
        coins = totalCoins % 100;
    }

    public void Increase(int amountNotes, int amountCoins)
    {
        int totalCoins = (notes * 100 + coins) + (amountNotes * 100 + amountCoins);
        notes = totalCoins / 100;
        coins = totalCoins % 100;
    }
}

public class Product
{
    private string name;
    private Money price;

    public Product(string name, int priceNotes, int priceCoins)
    {
        this.Name = name;
        this.Price = new Money(priceNotes, priceCoins);
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Money Price
    {
        get { return price; }
        set { price = value; }
    }

    public void DecreasePrice(int amountNotes, int amountCoins)
    {
        price.Decrease(amountNotes, amountCoins);
    }

    public void Display()
    {
        Console.WriteLine($"Назва: {Name}, Ціна: ");
        Price.Display();
    }
}


public class Warehouse
{
    private List<Product> products;
    private string unit;
    private int quantity;
    private DateTime lastDeliveryDate;

    public Warehouse(string unit)
    {
        this.products = new List<Product>();
        this.unit = unit;
    }

    public string Unit
    {
        get { return unit; }
        set { unit = value; }
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public DateTime LastDeliveryDate
    {
        get { return lastDeliveryDate; }
        set { lastDeliveryDate = value; }
    }

    public void AddProduct(Product product, int quantity, DateTime deliveryDate)
    {
        products.Add(product);
        this.quantity += quantity;
        this.lastDeliveryDate = deliveryDate;
    }

    public void RemoveProduct(Product product, int quantity)
    {
        if (this.quantity < quantity)
        {
            throw new InvalidOperationException("Недостатня кількість товару на складі");
        }
        products.Remove(product);
        this.quantity -= quantity;
    }

    public void Display()
    {
        Console.WriteLine($"Одиниця виміру: {unit}, Кількість: {quantity}, Дата останнього завозу: {lastDeliveryDate.ToShortDateString()}");
        foreach (var product in products)
        {
            product.Display();
        }
    }

    public List<Product> GetProducts()
    {
        return products;
    }
}

public class Reporting
{
    private Warehouse warehouse;

    public Reporting(Warehouse warehouse)
    {
        this.warehouse = warehouse;
    }

    public void RegisterIncomingProduct(Product product, int quantity, DateTime deliveryDate)
    {
        warehouse.AddProduct(product, quantity, deliveryDate);
        Console.WriteLine($"Продукт {product.Name} було завезено в кількості {quantity} {warehouse.Unit} на склад.");
    }

    public void RegisterOutgoingProduct(Product product, int quantity)
    {
        warehouse.RemoveProduct(product, quantity);
        Console.WriteLine($"Продукт {product.Name} було відвантажено в кількості {quantity} {warehouse.Unit} зі складу.");
    }

    public void InventoryReport()
    {
        Console.WriteLine("Звіт по інвентаризації:");
        warehouse.Display();
    }
}

// Приклад використання
public class Program
{
    public static void Main()
    {
        // Створення продуктів
        Product laptop = new Product("Laptop", 1500, 50);
        Product phone = new Product("Phone", 800, 25);

        // Створення складу
        Warehouse warehouse = new Warehouse("шт.");

        // Створення об'єкта для звітності
        Reporting reporting = new Reporting(warehouse);

        // Реєстрація надходження товарів
        reporting.RegisterIncomingProduct(laptop, 10, DateTime.Now);
        reporting.RegisterIncomingProduct(phone, 20, DateTime.Now);

        // Звіт по інвентаризації
        reporting.InventoryReport();

        // Реєстрація відвантаження товарів
        reporting.RegisterOutgoingProduct(phone, 5);

        // Звіт по інвентаризації після відвантаження
        reporting.InventoryReport();
    }
}