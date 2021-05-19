using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseBuilder.Entities;

namespace DatabaseBuilder.FixedCreator
{
    public class VatCreator : IFix
    {
        private MyContext __Context { get; set; }
        private VAT VatValue = new VAT()
        {
            DateSince = new DateTime(2011, 01, 01),
            Value = 0.23M
        };

        public VatCreator(string connectionString)
        {
            __Context = new MyContext(connectionString);
            __Context.Database.EnsureCreated();
        }

        private bool CreateVAT()
        {
            __Context.VAT.Add(VatValue);
            if (!(__Context.SaveChanges() == 1))
            {
                Console.WriteLine($"An error occured while trying to save a VAT type into the DB\n");
                return false;
            }
            else
            {
                Console.WriteLine($"> VAT value saved.");
                return true;
            }
        }

        public void SaveToDatabaseSequentially()
        {
            if (this.CreateVAT())
                Console.WriteLine("VAT was successfully added to the database!");
            else
                Console.WriteLine("Saving VAT occured with some kind of a problem.\n" +
                                "Check the database for details.");
        }
    }
}
