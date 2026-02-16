using Microsoft.EntityFrameworkCore;
using SegurosNET8_Clean.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.RepositoryEFCore.DataContext;

public class AseguradoraContext : DbContext
{
    public AseguradoraContext(DbContextOptions<AseguradoraContext> options) : base(options)
    {

    }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Seguro> Seguros { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);        
    }
}
