using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UTMAPP.Models;

namespace UTMAPP.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/v1/values")]
    public class ValuesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public ValuesController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cautam solutiile ecuatiei.
        /// </summary>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost("ecuation")]
        public IActionResult CalcEcuation([FromBody] CalcModel vals)
        {
            double delt = Math.Sqrt(vals.b) - 4 * vals.a * vals.c;
            double x1, x2;
            CalcValue result = _context.GetByValues(vals);

            if (result != null)
            {
                Console.WriteLine(result);
                return Ok(result);
            }

            if (delt < 0)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "Ecuatia nu are solutii",
                });
            }

            if (delt == 0)
            {
                x1 = x2 = -vals.b / (2 * vals.a);
            }
            else
            {
                x1 = (-vals.b - Math.Sqrt(delt)) / (2 * vals.a);
                x2 = (-vals.b + Math.Sqrt(delt)) / (2 * vals.a);
            }

            _context.CalcValues.Add(new CalcValue()
            {
                a = vals.a,
                b = vals.b,
                c = vals.c,
                x1 = x1,
                x2 = x2,
            });
            _context.SaveChanges();

            return Ok(_context.GetByValues(vals));
        }
    }
}
