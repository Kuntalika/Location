using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LocationDetailsAPI.Models
{
    public class Location
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string LocationID { get; set; }
        public string City { get; set; }
        public string Airport { get; set; }
    }
}
