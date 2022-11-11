﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp2Server.Data;

namespace BlazorApp2Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly BlazorApp2ServerContext _context;

        public FeaturesController(BlazorApp2ServerContext context)
        {
            _context = context;
        }

        // GET: api/Features
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feature>>> GetFeature()
        {
          if (_context.Feature == null)
          {
              return NotFound();
          }
            return await _context.Feature.ToListAsync();
        }

        // GET: api/Features/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feature>> GetFeature(int id)
        {
          if (_context.Feature == null)
          {
              return NotFound();
          }
            var feature = await _context.Feature.FindAsync(id);

            if (feature == null)
            {
                return NotFound();
            }

            return feature;
        }

        // PUT: api/Features/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeature(int id, Feature feature)
        {
            if (id != feature.Id)
            {
                return BadRequest();
            }

            _context.Entry(feature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Features
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Feature>> PostFeature(Feature feature)
        {
          if (_context.Feature == null)
          {
              return Problem("Entity set 'BlazorApp2ServerContext.Feature'  is null.");
          }
            _context.Feature.Add(feature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeature", new { id = feature.Id }, feature);
        }

        // DELETE: api/Features/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            if (_context.Feature == null)
            {
                return NotFound();
            }
            var feature = await _context.Feature.FindAsync(id);
            if (feature == null)
            {
                return NotFound();
            }

            _context.Feature.Remove(feature);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeatureExists(int id)
        {
            return (_context.Feature?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
