using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationDetailsAPI.Models;
using LocationDetailsAPI.Services;
using MongoDB.Driver;

namespace LocationDetailsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationDetailsService _LocationDetailsService;

        public LocationController(LocationDetailsService LocationDetailsService)
        {
            _LocationDetailsService = LocationDetailsService;
        }

        [HttpGet]
        public ActionResult<List<Location>> Get() =>
            _LocationDetailsService.Get();

        // [Route("api/[controller]/{id?}")]
        [HttpGet("{id}")]
        public ActionResult<Location> Get(string id)
        {
            var Location = _LocationDetailsService.Get(id);

            if (Location == null)
            {
                return NotFound();
            }

            return Location;
        }

        [HttpPost]
        public ActionResult<Location> Create(Location Location)
        {
            _LocationDetailsService.Create(Location);

            return CreatedAtRoute("GetLocation", new { id = Location._id.ToString() }, Location);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Location LocationIn)
        {
            var Location = _LocationDetailsService.Get(id);

            if (Location == null)
            {
                return NotFound();
            }

            _LocationDetailsService.Update(id, LocationIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Location = _LocationDetailsService.Get(id);

            if (Location == null)
            {
                return NotFound();
            }

            _LocationDetailsService.Remove(Location._id);

            return NoContent();
        }
    }
}
