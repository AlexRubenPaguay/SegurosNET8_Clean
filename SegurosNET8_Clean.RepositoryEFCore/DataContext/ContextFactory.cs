using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegurosNET8_Clean.RepositoryEFCore.DataContext;

public class ContextFactory : IDesignTimeDbContextFactory<AseguradoraContext>
{
    public ContextFactory()
    {

    }
    public AseguradoraContext CreateDbContext(string[] args)
    {
        var OptionsBuilder = new DbContextOptionsBuilder<AseguradoraContext>();
        //OptionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AseguradoraBV;User ID=sa;Password=root ;Encrypt=False;Integrated Security=True; Trusted_Connection=true;");
        return new AseguradoraContext(OptionsBuilder.Options);
    }
}
