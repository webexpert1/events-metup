using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get() 
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
            // return new[] {"value1", "value2"};
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id) {
            var value = await _context.Values.FindAsync(id);
            return Ok(value);
        }
    }

}
