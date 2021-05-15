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
        private MyContext __Context = new MyContext("");
        
        private List<Parameter> Parameters = new List<Parameter>()
        {
            new Parameter {ParameterID = 1, ParameterName = "Timing", ParameterDescription = "Frequency at which the part works, given in MHz or GHz."},
            new Parameter {ParameterID = 2, ParameterName = "Socket", ParameterDescription = "Processor socket type."},
            new Parameter {ParameterID = 3, ParameterName = "RAM memory", ParameterDescription = "Describes the amount of RAM memory provided by the product."},
            new Parameter {ParameterID = 4, ParameterName = "Threads", ParameterDescription = "Quantity of threads the product provides."},
            new Parameter {ParameterID = 5, ParameterName = "Cores", ParameterDescription = "Quantity of cores the product provides."},
            new Parameter {ParameterID = 6, ParameterName = "Power demand", ParameterDescription = "Describes how much power the part requires to run properly."},
            new Parameter {ParameterID = 7, ParameterName = "Memory", ParameterDescription = ""},
            new Parameter {ParameterID = 8, ParameterName = "Memory type", ParameterDescription = "Memory standard used by the product."},
            new Parameter {ParameterID = 9, ParameterName = "Slot type", ParameterDescription = "Type of input/output slot - HDMI, USB, VGA, etc."},
            new Parameter {ParameterID = 10, ParameterName = "Length", ParameterDescription = ""},
            new Parameter {ParameterID = 11, ParameterName = "Width", ParameterDescription = ""},
            new Parameter {ParameterID = 12, ParameterName = "Height", ParameterDescription = ""},
            new Parameter {ParameterID = 13, ParameterName = "Color", ParameterDescription = "Color(s) of the given product."},
            new Parameter {ParameterID = 14, ParameterName = "Certificate", ParameterDescription = "Type of certificate."},
            new Parameter {ParameterID = 15, ParameterName = "Efficiency", ParameterDescription = "Percentage of how much power delivered is used properly."},
            new Parameter {ParameterID = 15, ParameterName = "Maximum power", ParameterDescription = "Peek power output produced by the device."}
        };

        public ParameterCreator(ref MyContext context)
        {
            __Context = context;
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
