using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace UTMAPP.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<CalcValue> CalcValues { get; set; }

        public CalcValue GetByValues(CalcModel search)
        {
            return CalcValues
                .Where(v => v.a == search.a && v.b == search.b && v.c == search.c)
                .ToList()
                .FirstOrDefault();
        }

    }

    public class CalcModel
    {
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
    }
}
