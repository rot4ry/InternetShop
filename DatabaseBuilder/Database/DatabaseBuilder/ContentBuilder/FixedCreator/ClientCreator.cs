using DatabaseBuilder.Entities;
using System;
using System.Collections.Generic;

namespace DatabaseBuilder.FixedCreator
{
    /// <summary>
    /// Creates Client data and saves them in the DB
    /// </summary>
    public class ClientCreator : IFix
    {
        private MyContext __Context = new MyContext("");
        private List<Client> Clients = new List<Client>
        {
            new Client(){ ClientID = 1, FirstName = "Jan", SecondName = "Kowalski", EmailAddress = "jkowalski@interia.pl", Country = "Poland", City = "Wrocław", Street = "Kwiatowa", BuildingNumber = "32", IsConstClient = true, Login = "kowalskJ", Password = "j@n3k" },
            new Client(){ ClientID = 2, FirstName = "Steve", SecondName = "Jobs", EmailAddress ="stevie@pear.com", Country = "USA", City = "Palo Alto", Street = "31st Street", BuildingNumber = "1", FlatNumber = 32, IsConstClient = false, Login = "st3v3", Password = "jobs@32" },
            new Client(){ ClientID = 3, FirstName = "Mako", SecondName = "Sato", EmailAddress ="sileighty88@stars.jp", Country = "Japan", City = "Tokio", Street = "", BuildingNumber = "323f", FlatNumber = 17, IsConstClient = false, Login = "msato180", Password = "noonesleepsintoky0" },
            new Client(){ ClientID = 4, FirstName = "Emily", SecondName = "Thompson", EmailAddress ="mlthmpsn@zef.com", Country = "Republic of South Africa", City = "Cape Town", Street = "Station Rd", BuildingNumber = "12c", FlatNumber = 8, IsConstClient = true, Login = "pewpewpew", Password = "sayHelloToMyLittleFriend" }
        };

        public ClientCreator(MyContext context)
        {
            __Context = context;
        }

        private bool CreateClients()
        {
            foreach (Client client in Clients)
            {
                __Context.Client.Add(client);
                if (!(__Context.SaveChanges() == 1))
                {
                    Console.WriteLine($"An error occured while trying to save a Client type into the DB\n" +
                                    $"Client ID = {client.ClientID}");
                    return false;
                }
            }
            return true;
        }

        public void SaveToDatabaseSequentially()
        {
            if (this.CreateClients())
                Console.WriteLine("Clients were successfully added to the database!");
            else
                Console.WriteLine("Saving Clients occured with some kind of a problem.\n" +
                                "Check the database for details.");
        }
    }
}
