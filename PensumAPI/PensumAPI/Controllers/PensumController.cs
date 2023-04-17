#nullable disable
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PensumAPI.Data;
using PensumAPI.Models;

namespace PensumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensumController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PensumController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/API
        [HttpGet]
    public async Task<ActionResult<IEnumerable<Lektion>>> GetLektions()
        {
            return await _context.Lektions.ToListAsync();
        }


        

        [HttpGet(template: "{klasse}")]
        public async Task<ActionResult<IEnumerable<Lektion>>>GetLektionKlasse(string klasse)
        {
            Console.WriteLine(klasse);
            var lektion = await _context.Lektions.Where(l => l.Klasse == klasse).ToListAsync();
            
            if (lektion.Count <= 0)
            {
                return NotFound();
            }

            return lektion;
        }
        private bool LektionExists(int id)
        {
            return _context.Lektions.Any(e => e.Id == id);
        }
    }
}
