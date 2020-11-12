using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using QueuingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueuingAPI.Services
{
    public class ApartmentsService
    {
        private readonly IMongoCollection<Apartments> apartments;

        public ApartmentsService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("ServerName"));
            IMongoDatabase database = client.GetDatabase(config.GetConnectionString("DatabaseName"));
            apartments = database.GetCollection<Apartments>("Apartments");
        }

        public List<Apartments> Get()
        {
            return apartments.Find(apartment => true).ToList();
        }

        public Apartments Get(string Id)
        {
            return apartments.Find(apartment => apartment.objectId == Id).FirstOrDefault();
        }

        public Apartments Create(Apartments apartment)
        {
            apartments.InsertOne(apartment);
            return apartment;
        }

        public void Update(string Id, Apartments apartmentIn)
        {
            apartments.ReplaceOne(apartment => apartment.objectId == Id, apartmentIn);
        }

        public void Remove(Apartments apartmentIn)
        {
            apartments.DeleteOne(apartment => apartment.objectId == apartmentIn.objectId);
        }

        public void Remove(string Id)
        {
            apartments.DeleteOne(apartment => apartment.objectId == Id);
        }
    }
}
