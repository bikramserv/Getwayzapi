using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Getwayzapi.Models;
using System.Net;

namespace Getwayzapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapDatasController : ControllerBase
    {
        private readonly MapDataContext _context;

        public MapDatasController(MapDataContext context)
        {
            _context = context;
        }

        // GET: api/MapDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MapData>>> GetMapData()
        {
            return await _context.MapData.ToListAsync();
        }

        // GET: api/MapDatas
        [HttpGet("{postCode}")]
        public async Task<ActionResult<IEnumerable<MapData>>> GetMapData(string postCode)
        {
            return await _context.MapData.Where(x => x.PostCode == postCode).ToListAsync();
        }

        /*  // GET: api/MapDatas1/5
          [HttpGet]
          public async Task<ActionResult<MapData>> GetMapData()
          {
              var mapData = await _context.MapData.FindAsync(id);

              if (mapData == null)
              {
                  return NotFound();
              }

              return mapData;
          }*/

        // PUT: api/MapDatas1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMapData(Guid id, MapData mapData)
        {
            var md = _context.MapData.FirstOrDefault(x => x.Id == id);

            if (md is null)
            {
                return NotFound();
            }

            try
            {
                if (mapData.PostCode is not null)
                    md.PostCode = mapData.PostCode;
                if (mapData.PlotNo is not null)
                    md.PlotNo = mapData.PlotNo;
                if (mapData.Longitude is not null)
                    md.Longitude = mapData.Longitude;
                if (mapData.Latitude is not null)
                    md.Latitude = mapData.Latitude;
                _context.MapData.Update(md);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                LogException(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return Accepted();
        }

        private void LogException(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // POST: api/MapDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MapData>> PostMapData(MapData mapData)
        {
            _context.MapData.Add(mapData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMapData", new { id = mapData.Id }, mapData);
        }

        // DELETE: api/MapDatas1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMapData(Guid id)
        {
            var mapData = await _context.MapData.FindAsync(id);
            if (mapData == null)
            {
                return NotFound();
            }

            _context.MapData.Remove(mapData);
            await _context.SaveChangesAsync();

            return StatusCode((int)HttpStatusCode.OK);
        }

        private bool MapDataExists(Guid id)
        {
            return _context.MapData.Any(e => e.Id == id);
        }
    }
}
