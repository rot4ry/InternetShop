using DatabaseBuilder.Entities;
using System;
using System.Collections.Generic;

namespace DatabaseBuilder.FixedCreator
{
    /// <summary>
    /// Builds a fixed table of type Parameter
    /// </summary>
    public class ParameterCreator : IFix
    {
        private MyContext __Context { get; set; }
        private List<Parameter> Parameters = new List<Parameter>()
        {
            new Parameter { ParameterName = "Timing", ParameterDescription = "Frequency at which the part works, given in MHz or GHz."},
            new Parameter { ParameterName = "Socket", ParameterDescription = "Processor socket type."},
            new Parameter { ParameterName = "RAM memory", ParameterDescription = "Describes the amount of RAM memory provided by the product."},
            new Parameter { ParameterName = "Threads", ParameterDescription = "Quantity of threads the product provides."},
            new Parameter { ParameterName = "Cores", ParameterDescription = "Quantity of cores the product provides."},
            new Parameter { ParameterName = "Power demand", ParameterDescription = "Describes how much power the part requires to run properly."},
            new Parameter { ParameterName = "Memory", ParameterDescription = ""},
            new Parameter { ParameterName = "Memory type", ParameterDescription = "Memory standard used by the product."},
            new Parameter { ParameterName = "Slot type", ParameterDescription = "Type of input/output slot - HDMI, USB, VGA, etc."},
            new Parameter { ParameterName = "Length", ParameterDescription = ""},
            new Parameter { ParameterName = "Width", ParameterDescription = ""},
            new Parameter { ParameterName = "Height", ParameterDescription = ""},
            new Parameter { ParameterName = "Color", ParameterDescription = "Color(s) of the given product."},
            new Parameter { ParameterName = "Certificate", ParameterDescription = "Type of certificate."},
            new Parameter { ParameterName = "Efficiency", ParameterDescription = "Percentage of how much power delivered is used properly."},
            new Parameter { ParameterName = "Maximum power", ParameterDescription = "Peek power output produced by the device."}
        };

        public ParameterCreator(string connectionString)
        {
            __Context = new MyContext(connectionString);
            __Context.Database.EnsureCreated();
        }

        private bool CreateParameters()
        {
            foreach (Parameter parameter in Parameters)
            {
                __Context.Parameter.Add(parameter);
                if (!(__Context.SaveChanges() == 1))
                {
                    Console.WriteLine($"An error occured while trying to save a Parameter type into the DB\n" +
                                    $"Parameter ID = {parameter.ParameterID}");
                    return false;
                }
                else Console.WriteLine($"> Parameter {parameter.ParameterID} saved.");
                
            }
            return true;

        }

        public void SaveToDatabaseSequentially()
        {
            if (this.CreateParameters())
                Console.WriteLine("Parameters were successfully added to the database!");
            else
                Console.WriteLine("Saving Parameters occured with some kind of a problem.\n" +
                                "Check the database for details.");
        }
    }
}
