﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TarjetaCreditoAPI;
using TarjetaCreditoAPI.Models;

namespace TarjetaCreditoAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaCreditoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TarjetaCreditoController(ApplicationDbContext context)
        {
            _context = context;
        }


        //Get: api/TarjetaCredito
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarjetaCredito>>> GetTarjetaCredito()
        {
            return await _context.TarjetaCredito.ToListAsync();
        }

        //Get: api/TarjetaCredito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TarjetaCredito>> GetTarjetaCredito(int id)
        {
            var tarjetaCredito = await _context.TarjetaCredito.FindAsync(id);

            if (tarjetaCredito == null)
            {
                return NotFound();
            }

            return tarjetaCredito;
        }

        //PUT: api/TarjetaCredito/5
        // To Protect from overposting attack, enables the specific properties you want to bind to

        //update
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarjetaCredito(int id, TarjetaCredito tarjetaCredito)
        {

            if (id != tarjetaCredito.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarjetaCredito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarjetaCreditoExists(id))
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


        //Post: api/TarjetaCredito
        [HttpPost]

        public async Task<ActionResult<TarjetaCredito>> PostTarjetaCredito(TarjetaCredito tarjetaCredito)
        {
            _context.TarjetaCredito.Add(tarjetaCredito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarjetaCredito", new { id = tarjetaCredito.Id }, tarjetaCredito);
        }


        //DELETE: api/TarjetaCredito/5
        [HttpDelete("{id}")]


        public async Task<ActionResult<TarjetaCredito>> DeleteTarjetaCredito(int id)
        {

            var tarjetaCredito = await _context.TarjetaCredito.FindAsync(id);
            if(tarjetaCredito == null)
            {
                return NotFound();
            }

            _context.TarjetaCredito.Remove(tarjetaCredito);

            await _context.SaveChangesAsync();

            return tarjetaCredito;
        }

        private bool TarjetaCreditoExists(int id)
        {
            return _context.TarjetaCredito.Any(e => e.Id == id);
        }


    }
}

