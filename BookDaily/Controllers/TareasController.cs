using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookDaily.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.Json.Nodes;

namespace BookDaily.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly BookDailyDbContext _context;

        public TareasController(BookDailyDbContext context)
        {
            _context = context;
        }

        // GET: api/Tareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
        {
            try
            {
                return await _context.Tareas.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework like Serilog, NLog, etc.)
                // For now, we'll just return a generic error message
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // GET: api/Tareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetTarea(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);

            if (tarea == null)
            {
                return NotFound("La tarea No existe!\nPor favor indique un ID correcto!");
            }

            return tarea;
        }

        // POST: api/Tareas

        [HttpPost]
        public async Task<ActionResult<Tarea>> PostTarea([FromBody] Tarea tarea)
        {
            var respuesta = new JsonObject { ["data"] = string.Empty, ["error"] = string.Empty };

            if (tarea == null)
            {
                respuesta["error"] = "Tarea no puede ser nula.";
                return BadRequest(respuesta);
            }

            if (string.IsNullOrWhiteSpace(tarea.Descripcion))
            {
                respuesta["error"] = "La descripción es requerida.";
                return BadRequest(respuesta);
            }

            if (tarea.FechaVencimiento == default)
            {
                respuesta["error"] = "La fecha de vencimiento es requerida.";
                return BadRequest(respuesta);
            }

            if (string.IsNullOrWhiteSpace(tarea.Prioridad))
            {
                respuesta["error"] = "La prioridad es requerida.";
                return BadRequest(respuesta);
            }

            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();

            respuesta["data"] = "Tarea creada con éxito";
            return CreatedAtAction(nameof(GetTarea), new { id = tarea.Id }, respuesta);
        }
            //[HttpPost]
            //public async Task<ActionResult<Tarea>> PostTarea([FromBody] Tarea tarea)
            //{
            //    if (tarea == null)
            //    {
            //        return BadRequest("Tarea no puede ser nula.");
            //    }

            //    _context.Tareas.Add(tarea);
            //    await _context.SaveChangesAsync();

            //    return CreatedAtAction(nameof(GetTarea), new { id = tarea.Id }, tarea);
            //}

            // PUT: api/Tareas/5
            [HttpPut("{id}")]
        public async Task<IActionResult> PutTarea(int id, [FromBody] Tarea tarea)
        {
            var respuesta = new JsonObject{ ["data"] = string.Empty, ["error"] = string.Empty };

            if (id != tarea.Id)
            {
                return BadRequest("El ID de la tarea no coincide.");
            }

            _context.Entry(tarea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                respuesta["data"] = "Los campos de la tarea se han actualizado con exito!";
            }
            catch (DbUpdateConcurrencyException ex) 
            {
                if (!TareaExists(id))
                {
                    return NotFound();
                }

                respuesta["error"] = ex.Message;
                throw; // Re-lanzar la excepción para que sea manejada por el middleware
            }

            return Ok(respuesta);
        }

        // DELETE: api/Tareas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarea(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            //string alerta = "La Tarea se ha eliminado con exito"; comentario para agregar cuando se haya realizado con exito
            if (tarea == null)
            {
                return NotFound("La Tarea que intenta eliminar no existe!\nVerifique el ID e intenlo nuevamente!");
            }

            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();

            return Ok("La Tarea se ha eliminado con exito");
        }

        private bool TareaExists(int id)
        {
            return _context.Tareas.Any(e => e.Id == id);
        }
    }
}
