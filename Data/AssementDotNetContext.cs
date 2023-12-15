using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssementDotNet.AtDotnet.Models;

namespace AssementDotNet.AtDotnet.Data
{
    public class AssementDotNetContext : DbContext
    {
        public AssementDotNetContext(DbContextOptions<AssementDotNetContext> options)
            : base(options)
        {
        }

        public DbSet<PersonagemCreator> PersonagemCreator { get; set; } = default!;
    }
}
