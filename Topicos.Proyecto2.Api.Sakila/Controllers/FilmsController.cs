using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Topicos.Proyecto2.Sakila.Model.MyModels;

namespace Topicos.Proyecto2.Api.Sakila.Controllers
{
    [Route("api/Film")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly sakilaContext _context;
        private readonly IMapper _mapp;

        public FilmsController(IMapper mapper)
        {
            _context = new sakilaContext();
            _mapp = mapper;
        }

        // GET: api/Films
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoModel.DtoFilm>>> GetFilms(int pageSize = 5, int pageNumber = 5)
        {
            var film = await _context.Films.OrderBy(f => f.Title).
                Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

            if (film == null)
            {
                return NotFound();
            }

            var filmmapeado = _mapp.Map<List<DtoModel.DtoFilm>>(film);

            return filmmapeado;
        }

        // GET: api/Films/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DtoModel.DtoFilm>> GetFilm(int id)
        {
            var film = (await _context.Films.Include(a => a.FilmActors)
                            .Include(c => c.FilmCategories).Where(f => f.FilmId == id)
                            .ToListAsync()).FirstOrDefault();

            if (film == null)
            {
                return NotFound();
            }

            var filmmapeado = _mapp.Map<DtoModel.DtoFilm>(film);
            return filmmapeado;
        }

        // GET: api/Customers/PagedQuery/?pageNumber=3?pageSize=5
        [HttpGet("PagedQuery/")]
        public async Task<ActionResult<IEnumerable<DtoModel.DtoFilm>>> GetCustomerPaged(int pageNumber, int pageSize)
        {

            var film = await _context.Films.OrderBy(c => c.Title).
                Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

            if (film == null)
            {
                return NotFound();
            }

            var customermapeado = _mapp.Map<List<DtoModel.DtoFilm>>(film);

            return customermapeado;
        }

        // PUT: api/Films/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm(int id, Film film)
        {
            if (id != film.FilmId)
            {
                return BadRequest();
            }

            _context.Entry(film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
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

        // POST: api/Films
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Film>> PostFilm(Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilm", new { id = film.FilmId }, film);
        }

        // DELETE: api/Films/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            _context.Films.Remove(film);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e => e.FilmId == id);
        }
    }
}
