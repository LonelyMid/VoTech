﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTI.VoTech.Data;
using DTI.VoTech.Models;

namespace DTI.VoTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotacoesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VotacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Votacao>>> GetVotacoes()
        {
            return await _context.Votacoes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Votacao>> GetVotacao(int id)
        {
            var votacao = await _context.Votacoes.FindAsync(id);

            if (votacao == null)
            {
                return NotFound();
            }

            return votacao;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVotacao(int id, Votacao votacao)
        {
            if (id != votacao.VotacaoId)
            {
                return BadRequest();
            }

            _context.Entry(votacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VotacaoExists(id))
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


        [HttpPost]
        public async Task<ActionResult<Votacao>> PostVotacao(Votacao votacao)
        {
            _context.Votacoes.Add(votacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVotacao", new { id = votacao.VotacaoId }, votacao);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Votacao>> DeleteVotacao(int id)
        {
            var votacao = await _context.Votacoes.FindAsync(id);
            if (votacao == null)
            {
                return NotFound();
            }

            _context.Votacoes.Remove(votacao);
            await _context.SaveChangesAsync();

            return votacao;
        }

        private bool VotacaoExists(int id)
        {
            return _context.Votacoes.Any(e => e.VotacaoId == id);
        }
    }
}
