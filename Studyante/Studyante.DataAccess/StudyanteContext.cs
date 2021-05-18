using Microsoft.EntityFrameworkCore;

using Studyante.DataAccess.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studyante.DataAccess
{
    public class StudyanteContext : DbContext
    {
        public StudyanteContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

    }
}
