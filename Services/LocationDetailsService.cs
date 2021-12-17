using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationDetailsAPI.Models;
using MongoDB.Driver;

namespace LocationDetailsAPI.Services
{
    public class LocationDetailsService
    {
        private readonly IMongoCollection<Location> _LocationDetails;

        public LocationDetailsService(ILocationConfiguration settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _LocationDetails = database.GetCollection<Location>(settings.LocationDetailsCollectionName);
        }


        public List<Location> Get() =>
         _LocationDetails.Find(Location => true).ToList();

        //public async Task<List<Employee>> GetAsync() =>
        //await _EmployeeDetails.Find(_ => true).ToListAsync();

        public Location Get(string id) =>
        _LocationDetails.Find<Location>(Location => Location._id == id).FirstOrDefault();

        public Location Create(Location Location)
        {
            _LocationDetails.InsertOne(Location);
            return Location;
        }

        public void Update(string id, Location LocationIn) =>
            _LocationDetails.ReplaceOne(Location => Location._id == id, LocationIn);

        public void Remove(Location LocationIn) =>
            _LocationDetails.DeleteOne(Location => Location._id == LocationIn._id);

        public void Remove(string id) =>
            _LocationDetails.DeleteOne(Location => Location._id == id);
    }
}

