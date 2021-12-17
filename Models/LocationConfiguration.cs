using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationDetailsAPI.Models;


namespace LocationDetailsAPI.Models
{
    public class LocationConfiguration : ILocationConfiguration
    {
        public string LocationDetailsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ILocationConfiguration
    {
        string LocationDetailsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

}
