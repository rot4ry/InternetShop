using DatabaseBuilder.Entities;
using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Linq;

namespace DatabaseBuilder.RandomCreator
{
    /// <summary>
    /// Randomizes Product data and saves it in the DB
    /// </summary>
    public class ProductCreator
    {
        private string ConnectionString { get; set; }
        private MyContext __Context { get; set; }
        private List<Category> Categories { get; set; }     //list of categories in the db
        private List<Parameter> Parameters { get; set; }    //list of parameters in the db

        private static string[] Brands = new string[]
        {
            "Yntel", "MAD", "Loudium", "Princegem", "SuperY", "Deal", "Bench"
        };

        private static string[][] CategoriesNamesAndModels = new string[][]
        {
            new string[]{"Processor",            "i33", "i25", "Care", "ric3n" },
            new string[]{"Graphic card",         "GRX", "RRX", "FForce" },
            new string[]{"Motherboard",          "PpX32", "I321p", "L04Sx", "ff152" },
            new string[]{"Desktop RAM",          "X2201", "44sfd", "po32", "kgstn34" },
            new string[]{"Hard drive",           "Rpm220", "SuperBig309", "LLks2" },
            new string[]{"Solid state drive",    "QB326", "Asdf88", "X420p", "OmniSpeed342" },
            new string[]{"Computer cooling",     "Cll26", "PPal99s", "CmM24", "Cc125" },
            new string[]{"Computer power supply","260WX", "Mall44", "Pap", "Pk992" },
            new string[]{"Computer case",        "FullPC", "HalfWay", "E3e" },
            new string[]{"Speaker",              "GSound432", "Alf232", "LdBs9000"},
            new string[]{"Headphones",           "SmokeSet2", "GX6", "WaS55"},
            new string[]{"Computer mouse",       "MOU532", "DdW2", "32ILF"},
            new string[]{"Computer keyboard",    "Grass2", "ClicketyP3", "LFuneral01"},
            new string[]{"Computer monitor",     "GG23I", "OP221", "Cwa421"},
        };

        private string[] descriptions = new string[]
        {
            "Very cool item, works great, go buy it!",
            "Recommended by owners of other cool products.",
            "Remarkable.",
            "Below average.",
            "The definition of antiproduct!",
            "Something we didn't deserve but we got it.",
            "Something you don't deserve but you'll probably get it."
        };

        public ProductCreator(string connectionString)
        {
            ConnectionString = connectionString;
            __Context = new MyContext(connectionString);
            __Context.Database.EnsureCreated();
        }

        public void CreateProduct()
        {
            int productID = GetTopProductID() + 1;

            Category category = GetCategory();
            string brand = GetBrand();
            string productName = GetName((category.CategoryID)%14, brand);

            Product product = new Product()
            {
                CategoryID = category.CategoryID,
                ProductName = productName,
                Brand = brand,
                UnitPrice = GetPrice(),
                QtAvailable = GetRandom(3, 100),
                ProducerCode = GetCode(),
                ProductDescription = GetDescription()
            };

            __Context.Product.Add(product);
            if (!(__Context.SaveChanges() == 1))
            {
                Console.WriteLine($"An error occured while trying to save a Product type into the DB\n" +
                                $"Parameter ID = {product.ProductID}");
            }
            else Console.WriteLine($"> Product {product.ProductID} saved., CAT{product.CategoryID}");

            List<ProductParameter> productParameters = new List<ProductParameter>();
            switch (product.CategoryID)
            {
                case 1:
                    productParameters.Add(new ProductParameter() { ParameterID = 1, ProductID = productID, ParameterDecimal = GetRandomDecimal(10), ParameterValueText="GHz" });
                    productParameters.Add(new ProductParameter() { ParameterID = 2, ProductID = productID, ParameterValueText = $"Socket {GetRandom(100, 2000)}" });
                    productParameters.Add(new ProductParameter() { ParameterID = 4, ProductID = productID, ParameterValueInt = GetRandom(4, 20)});
                    productParameters.Add(new ProductParameter() { ParameterID = 5, ProductID = productID, ParameterValueInt = GetRandom(6, 12) });
                    productParameters.Add(new ProductParameter() { ParameterID = 6, ProductID = productID, ParameterValueInt = GetRandom(100, 140), ParameterValueText="Watt" });
                    break;

                case 2:
                    productParameters.Add(new ProductParameter() { ParameterID = 1, ProductID = productID, ParameterDecimal = GetRandomDecimal(10), ParameterValueText = "MHz" });  //taktowanie
                    productParameters.Add(new ProductParameter() { ParameterID = 3, ProductID = productID, ParameterDecimal = GetRandom(600, 900), ParameterValueText = "MB" });    //ram
                    productParameters.Add(new ProductParameter() { ParameterID = 6, ProductID = productID, ParameterValueInt = GetRandom(300, 360), ParameterValueText = "Watt" });
                    productParameters.Add(new ProductParameter() { ParameterID = 9, ProductID = productID, ParameterValueText = "HDMI, VGA, DVI" });                                //slot
                    productParameters.Add(new ProductParameter() { ParameterID = 10, ProductID = productID, ParameterValueInt = GetRandom(300, 360), ParameterValueText = "mm" });  //dł
                    productParameters.Add(new ProductParameter() { ParameterID = 11, ProductID = productID, ParameterValueInt = GetRandom(100, 160), ParameterValueText = "mm" });  //szer
                    productParameters.Add(new ProductParameter() { ParameterID = 12, ProductID = productID, ParameterValueInt = GetRandom(10, 30), ParameterValueText = "mm" });    //wys
                    break;
                case 3:
                    productParameters.Add(new ProductParameter() { ParameterID = 2, ProductID = productID, ParameterValueText = $"Socket {GetRandom(100, 2000)}" });
                    productParameters.Add(new ProductParameter() { ParameterID = 6, ProductID = productID, ParameterValueInt = GetRandom(100, 140), ParameterValueText = "Watt" });
                    productParameters.Add(new ProductParameter() { ParameterID = 10, ProductID = productID, ParameterValueInt = GetRandom(250, 300), ParameterValueText = "mm" });  //dł
                    productParameters.Add(new ProductParameter() { ParameterID = 11, ProductID = productID, ParameterValueInt = GetRandom(250, 300), ParameterValueText = "mm" });  //szer
                    productParameters.Add(new ProductParameter() { ParameterID = 12, ProductID = productID, ParameterValueInt = GetRandom(10, 35), ParameterValueText = "mm" });    //wys
                    break;
                case 4:
                    productParameters.Add(new ProductParameter() { ParameterID = 1, ProductID = productID, ParameterDecimal = GetRandomDecimal(10), ParameterValueText = "MHz" });  //taktowanie
                    productParameters.Add(new ProductParameter() { ParameterID = 3, ProductID = productID, ParameterDecimal = GetRandom(600, 900), ParameterValueText = "MB" });    //ram       
                    productParameters.Add(new ProductParameter() { ParameterID = 8, ProductID = productID, ParameterValueInt = GetRandom(100, 140), ParameterValueText = "DDR4" }); //mem type
                    break;
                case 5:
                    productParameters.Add(new ProductParameter() { ParameterID = 7, ProductID = productID, ParameterValueInt = GetRandom(512, 4096), ParameterValueText = "GB" });  //dł
                    productParameters.Add(new ProductParameter() { ParameterID = 10, ProductID = productID, ParameterValueInt = GetRandom(190, 220), ParameterValueText = "mm" });  //dł
                    productParameters.Add(new ProductParameter() { ParameterID = 11, ProductID = productID, ParameterValueInt = GetRandom(100, 150), ParameterValueText = "mm" });  //szer
                    productParameters.Add(new ProductParameter() { ParameterID = 12, ProductID = productID, ParameterValueInt = GetRandom(10, 30), ParameterValueText = "mm" });    //wys
                    break;
                case 6:
                    productParameters.Add(new ProductParameter() { ParameterID = 7, ProductID = productID, ParameterValueInt = GetRandom(512, 1024), ParameterValueText = "GB" });  //dł
                    productParameters.Add(new ProductParameter() { ParameterID = 10, ProductID = productID, ParameterValueInt = GetRandom(190, 220), ParameterValueText = "mm" });  //dł
                    productParameters.Add(new ProductParameter() { ParameterID = 11, ProductID = productID, ParameterValueInt = GetRandom(100, 150), ParameterValueText = "mm" });  //szer
                    productParameters.Add(new ProductParameter() { ParameterID = 12, ProductID = productID, ParameterValueInt = GetRandom(10, 30), ParameterValueText = "mm" });    //wy
                    break;
                case 7:
                    productParameters.Add(new ProductParameter() { ParameterID = 9, ProductID = productID, ParameterValueText = "4-pin PWM" });                                //slot
                    break;
                case 8:
                    productParameters.Add(new ProductParameter() { ParameterID = 10, ProductID = productID, ParameterValueInt = GetRandom(200, 240), ParameterValueText = "mm" });  //dł
                    productParameters.Add(new ProductParameter() { ParameterID = 11, ProductID = productID, ParameterValueInt = GetRandom(200, 240), ParameterValueText = "mm" });  //szer
                    productParameters.Add(new ProductParameter() { ParameterID = 12, ProductID = productID, ParameterValueInt = GetRandom(100, 120), ParameterValueText = "mm" });    //wys
                    productParameters.Add(new ProductParameter() { ParameterID = 14, ProductID = productID, ParameterValueText = "80 PLUS GOLD" });  //cert
                    productParameters.Add(new ProductParameter() { ParameterID = 15, ProductID = productID, ParameterValueText = "89%" });  //wyd
                    productParameters.Add(new ProductParameter() { ParameterID = 16, ProductID = productID, ParameterValueInt= GetRandom(500, 750),ParameterValueText = "Watt" });     //max power
                    break;
                case 9:
                    productParameters.Add(new ProductParameter() { ParameterID = 10, ProductID = productID, ParameterValueInt = GetRandom(300, 560), ParameterValueText = "mm" });  //dł
                    productParameters.Add(new ProductParameter() { ParameterID = 11, ProductID = productID, ParameterValueInt = GetRandom(200, 280), ParameterValueText = "mm" });  //szer
                    productParameters.Add(new ProductParameter() { ParameterID = 12, ProductID = productID, ParameterValueInt = GetRandom(300, 500), ParameterValueText = "mm" });    //wys
                    break;
                case 10:
                    productParameters.Add(new ProductParameter() { ParameterID = 6, ProductID = productID, ParameterValueInt = GetRandom(10, 25), ParameterValueText = "Watt" });
                    productParameters.Add(new ProductParameter() { ParameterID = 10, ProductID = productID, ParameterValueInt = GetRandom(200, 250), ParameterValueText = "mm" });  //dł
                    productParameters.Add(new ProductParameter() { ParameterID = 11, ProductID = productID, ParameterValueInt = GetRandom(100, 250), ParameterValueText = "mm" });  //szer
                    productParameters.Add(new ProductParameter() { ParameterID = 12, ProductID = productID, ParameterValueInt = GetRandom(100, 250), ParameterValueText = "mm" });    //wys
                    productParameters.Add(new ProductParameter() { ParameterID = 13, ProductID = productID, ParameterValueText = "Black/Gray/Red" });   //color
                    break;
                case 11:
                    productParameters.Add(new ProductParameter() { ParameterID = 13, ProductID = productID, ParameterValueText = "Black/Magenta" });   //color
                    break;
                case 12:
                    productParameters.Add(new ProductParameter() { ParameterID = 13, ProductID = productID, ParameterValueText = "White/Black" });   //color
                    break;
                case 13:
                    productParameters.Add(new ProductParameter() { ParameterID = 13, ProductID = productID, ParameterValueText = "Black/White/Dark Gray" });   //color
                    break;
                case 14:
                    productParameters.Add(new ProductParameter() { ParameterID = 10, ProductID = productID, ParameterValueInt = GetRandom(300, 360), ParameterValueText = "mm" });  //dł
                    productParameters.Add(new ProductParameter() { ParameterID = 11, ProductID = productID, ParameterValueInt = GetRandom(100, 160), ParameterValueText = "mm" });  //szer
                    productParameters.Add(new ProductParameter() { ParameterID = 12, ProductID = productID, ParameterValueInt = GetRandom(10, 30), ParameterValueText = "mm" });    //wys
                    productParameters.Add(new ProductParameter() { ParameterID = 13, ProductID = productID, ParameterValueText = "Black/White/Dark Gray" });
                    break;
            }

            foreach (ProductParameter pp in productParameters)
            {
                __Context.ProductParameter.Add(pp);
                if (!(__Context.SaveChanges() == 1))
                {
                    Console.WriteLine($"An error occured while trying to save a ProductParameter type into the DB");
                }
                else Console.WriteLine($"> ProductParameter saved {pp.ParameterID}.");
            }

            productParameters.Clear();
        }


        private string GetName(int catID, string brand)
        {
            int border = CategoriesNamesAndModels[catID].GetLength(0);

            StringBuilder name = new StringBuilder();
            name.Append(brand).Append(" ")
                .Append(CategoriesNamesAndModels[catID][GetRandom(1, border)]).Append(" ")
                .Append(CategoriesNamesAndModels[catID][0]);

            return name.ToString();
        }
        private int GetTopProductID()
        {
            string query = "SELECT MAX(ProductID) FROM Product";
            try
            {
                SqlConnection connection = new SqlConnection(this.ConnectionString);
                int id = connection.QuerySingle<int>(query);
                connection.Close();
                return id;
            }
            catch(Exception idException)
            {
                Console.WriteLine(idException.Message);
                return 0;
            }
        }
        private Category GetCategory()
        {
            int catID = GetRandom(1, Categories.Count());
            return Categories.Where(x => x.CategoryID == catID).First();
        }
        private string GetDescription()
        {
            return descriptions[GetRandom(0, descriptions.Length - 1)];
        }
        private string GetCode()
        {
            return Guid.NewGuid().ToString();
        }
        private decimal GetPrice()
        {
            return GetRandomDecimal(GetRandom(10, 100));
        }
        private string GetBrand()
        {
            return Brands[GetRandom(0, Brands.Length - 1)];
        }

        public void Initialize()
        {
            Categories = GetCategories();
            if(Categories is null)
            {
                Console.WriteLine("Couldn't get a list of Category items.");
            }
            else Console.WriteLine("Categories - [OK]");
            
            Parameters = GetParameters();
            if (Parameters is null)
            {
                Console.WriteLine("Couldn't get a list of Parameter items.");
            }
            else Console.WriteLine("Parameters - [OK]");
        }
        private int GetRandom(int l, int t)
        {
            Random rnd = new Random();
            return rnd.Next(l, t);
        }
        private decimal GetRandomDecimal(double f)
        {
            Random rnd = new Random();
            return (decimal)(0.3 * 3 * f + rnd.NextDouble() * f);
        }
        private List<Category> GetCategories()
        {
            string query = "SELECT * FROM Category";
            try
            {
                SqlConnection connection = new SqlConnection(this.ConnectionString);
                List<Category> categories = connection.Query<Category>(query).AsList<Category>();
                connection.Close();
                return categories;
            }
            catch (Exception queryException)
            {
                Console.WriteLine(queryException.Message);
                return null;
            }
        }
        private List<Parameter> GetParameters()
        {
            string query = "SELECT * FROM Parameter";
            try
            {
                SqlConnection connection = new SqlConnection(this.ConnectionString);
                List<Parameter> parameters = connection.Query<Parameter>(query).AsList<Parameter>();
                connection.Close();
                return parameters;
            }
            catch (Exception queryException)
            {
                Console.WriteLine(queryException.Message);
                return null;
            }
        }
    }
}
