using Assignment02_AdvC_.Classes;

namespace Assignment02_AdvC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
            new Product("Laptop", "Electronics", 1200, 10),
            new Product("Phone", "Electronics", 800, 25),
            new Product("Headphones", "Electronics", 150, 40),
            new Product("T-Shirt", "Clothing", 30, 100),
            new Product("Jeans", "Clothing", 60, 50),
            new Product("Chocolate", "Food", 5, 200),
            new Product("Coffee Beans", "Food", 15, 80),
            new Product("Novel", "Books", 20, 60),
            new Product("C# Book", "Books", 45, 30)
            };


            #region Task 01 - Smart Product Search

            Console.WriteLine("--- Electronics ---");
            var electronics = SearchProducts(products, IsElectronics);
            PrintWithStock(electronics);

            Console.WriteLine("\n--- Under $50 ---");
            var cheap = SearchProducts(products, IsCheap);
            PrintWithStock(cheap);

            Console.WriteLine("\n--- In Stock ---");
            var inStock = SearchProducts(products, HasStock);
            PrintWithStock(inStock);

            Console.WriteLine("\n--- Clothing under $100 ---");
            var clothing = SearchProducts(products, ClothingUnder100);
            PrintWithStock(clothing);

            #endregion

            #region Task 03.1 - Print Reports

            Console.WriteLine("\n--- Short Report ---");
            PrintReport(products, PrintShort);

            Console.WriteLine("\n--- Detailed Report ---");
            PrintReport(products, PrintDetailed);

            #endregion


        }

        #region Task 01 - Smart Product Search

        // Using Func<Product, bool> → flexible filter
        static List<Product> SearchProducts(List<Product> products, Func<Product, bool> condition)
        {
            List<Product> result = new List<Product>();

            foreach (var p in products)
            {
                if (condition(p))
                    result.Add(p);
            }

            return result;
        }

        static bool IsElectronics(Product p) => p.Category == "Electronics";
        static bool IsCheap(Product p) => p.Price < 50;
        static bool HasStock(Product p) => p.Stock > 0;
        static bool ClothingUnder100(Product p) => p.Category == "Clothing" && p.Price < 100;

        static void PrintWithStock(List<Product> list)
        {
            foreach (var p in list)
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
        }

        #endregion


        #region Task 03.1 - Print Reports
        // Using Action<Product> → performs operation (printing)
        static void PrintReport(List<Product> products, Action<Product> printer)
        {
            foreach (var p in products)
                printer(p);
        }

        static void PrintShort(Product p)
        {
            Console.WriteLine($"{p.Name} - ${p.Price}");
        }

        static void PrintDetailed(Product p)
        {
            Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}");
        }
        #endregion
    }
}
