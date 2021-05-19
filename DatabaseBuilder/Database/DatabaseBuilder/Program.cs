using System;
using System.IO;
using DatabaseBuilder.ContentBuilder;

namespace DatabaseBuilder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SayHello();
            string connectionString = SetConnectionString();
            int productQt = SetProductsQuanity();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Building the database. This could take a while so please be patient!");
            Console.ResetColor();

            Seed(connectionString, productQt);
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Building the database finished!\nPress any key to quit.");
            Console.ResetColor();
            Console.ReadLine();
        }

        public static void Seed(string connectionString, int productsQt)
        {
            Seeder seeder = new Seeder(connectionString, productsQt);
            seeder.AddClients();
            seeder.AddCategories();
            seeder.AddParameters();
            seeder.AddVat();

            seeder.AddProducts();
        }

        public static void SayHello()
        {
            Console.Write("Welcome to the ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[DatabaseBuilder]");
            Console.ResetColor();
            Console.Write("!");

            Console.WriteLine("\nThis software will generate a random database of:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" - products");
            Console.ResetColor();

            Console.WriteLine("and some fixed tables like:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" - parameters\n - categories\n - clients");
            Console.ResetColor();
        }

        public static string SetConnectionString()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEnter a filepath to a file containing the SQL Server connection string.");
            Console.ResetColor();
            string filePath = Console.ReadLine();
            string fileContent = File.ReadAllText(filePath);
            if (fileContent is null) 
                throw new NullReferenceException("File was not read.");
            else
                return fileContent;
        }

        public static int SetProductsQuanity()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nEnter a quantity of Products you want to create:\t");
            Console.ResetColor();
            string input = Console.ReadLine();
            int QT;
            Int32.TryParse(input, out QT);

            return QT;
        }
    }
}
