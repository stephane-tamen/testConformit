﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProgrammationConformit.Infrastructures;

namespace TestProgrammationConformit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentairesController : ControllerBase
    {
        private readonly ConformitContext _context;

        public CommentairesController(ConformitContext context)
        {
            _context = context;
        }

        // GET: api/Commentaires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commentaire>>> GetCommentaires()
        {
            return await _context.Commentaires.ToListAsync();
        }

        // GET: api/Commentaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commentaire>> GetCommentaire(int id)
        {
            var commentaire = await _context.Commentaires.FindAsync(id);

            if (commentaire == null)
            {
                return NotFound();
            }

            return commentaire;
        }

        // PUT: api/Commentaires/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentaire(int id, Commentaire commentaire)
        {
            if (id != commentaire.Id)
            {
                return BadRequest();
            }

            _context.Entry(commentaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentaireExists(id))
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

        // POST: api/Commentaires
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Commentaire>> PostCommentaire(Commentaire commentaire)
        {
            _context.Commentaires.Add(commentaire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentaire", new { id = commentaire.Id }, commentaire);
        }

        // DELETE: api/Commentaires/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Commentaire>> DeleteCommentaire(int id)
        {
            var commentaire = await _context.Commentaires.FindAsync(id);
            if (commentaire == null)
            {
                return NotFound();
            }

            _context.Commentaires.Remove(commentaire);
            await _context.SaveChangesAsync();

            return commentaire;
        }

        private bool CommentaireExists(int id)
        {
            return _context.Commentaires.Any(e => e.Id == id);
        }
    }
}
