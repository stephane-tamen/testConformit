﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProgrammationConformit.Infrastructures;
using TestProgrammationConformit.Infrastructures.Dto;
namespace TestProgrammationConformit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvenementsController : ControllerBase
    {
        private readonly ConformitContext _context;

        public EvenementsController(ConformitContext context)
        {
            _context = context;
        }

        // GET: api/Evenements
        [HttpGet]
        public async Task<ICollection<Evenement>> GetEvenements()
        {
            var evenements = await _context.Evenements.Include("Commentaires").ToListAsync();

            return evenements;
        }

        // GET: api/Evenements/paginate

        [HttpGet("paginate")]
        public   IEnumerable<Evenement>  GetEvenements(int pageNumber, int pageSize)
        {
            var evenements =  _context.Evenements.Include("Commentaires").Skip((pageNumber-1) * pageSize).Take(pageSize);
            
            return evenements;
        }

        // GET: api/Evenements/5
        [HttpGet("{id}")]
        public async Task<ICollection<Evenement>> GetEvenement(int id)
        {
            var evenement = await _context.Evenements.Where(b => b.Id == id).Include("Commentaires").ToListAsync();

           /* if (evenement == null)
            {
                return ;
            }*/
          

            return evenement;
           
        }

        // PUT: api/Evenements/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvenement(int id, Evenement evenement)
        {

            if (id != evenement.Id)
            {
                return BadRequest();
            }

            _context.Entry(evenement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvenementExists(id))
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

        // POST: api/Evenements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Evenement>> PostEvenement(Evenement evenement)
        {
            _context.Evenements.Add(evenement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvenement", new { id = evenement.Id }, evenement);
        }

        // DELETE: api/Evenements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Evenement>> DeleteEvenement(int id)
        {
            var evenement = await _context.Evenements.FindAsync(id);
            if (evenement == null)
            {
                return NotFound();
            }

            _context.Evenements.Remove(evenement);
            await _context.SaveChangesAsync();

            return evenement;
        }

        private bool EvenementExists(int id)
        {
            return _context.Evenements.Any(e => e.Id == id);
        }
    }
}
