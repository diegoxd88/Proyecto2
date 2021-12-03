using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Topicos.Proyecto2.Sakila.Model.Model;

namespace Topicos.Proyecto2.Api.Sakila.Controllers
{
    [Route("api/Store")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly sakilaContext _context;
        private readonly IMapper _mapp;

        public StoresController(IMapper mapper)
        {
            _context = new sakilaContext();
            _mapp = mapper;
        }

        // GET: api/Stores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> GetStores()
        {
            return await _context.Stores.ToListAsync();
        }

        // GET: api/Stores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOModels.DtoAddress>> GetStore(int id)
        {
            // var store = await _context.Stores.FindAsync(id);

            var store = (await _context.Stores.Include(a => a.Address)
             .ThenInclude(c => c.City)
             .ThenInclude(c => c.Country)
             .Where(s => s.StoreId == id).ToListAsync()).FirstOrDefault();

            if (store == null)
            {
                return NotFound();
            }

            var storemapeado = _mapp.Map<DTOModels.DtoAddress>(store);

            return storemapeado;
        }

        // GET: api/Customers/PagedQuery/?pageNumber=#?pageSize=#
        [HttpGet("PagedQuery/")]
        public async Task<ActionResult<IEnumerable<DTOModels.DtoStore>>> GetCustomerPaged(int pageNumber, int pageSize)
        {

            var store = await _context.Stores.Include(a => a.Address)
                .ThenInclude(c => c.City)
                .ThenInclude(c => c.Country)
                .Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

            if (store == null)
            {
                return NotFound();
            }

            var storemapeado = _mapp.Map<List<DTOModels.DtoStore>>(store);

            return storemapeado;
        }

        // PUT: api/Stores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStore(int id, Store store)
        {
            if (id != store.StoreId)
            {
                return BadRequest();
            }

            _context.Entry(store).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
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

        // POST: api/Stores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Store>> PostStore(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStore", new { id = store.StoreId }, store);
        }

        // DELETE: api/Stores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var store = await _context.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoreExists(int id)
        {
            return _context.Stores.Any(e => e.StoreId == id);
        }
    }
}
