using Microsoft.EntityFrameworkCore;
using PersonRegister.Data;
using PersonRegister.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegister;

public class Startup
{
    static async Task Main(string[] args)
    {
        var contextFactory = new PersonRegisterDbContextFactory();
        var dbContext = contextFactory.CreateDbContext(args);

        await dbContext.Database.MigrateAsync();

        var region = new Region()
        {
            Name = "Sofia",
            Person = new List<Person>()
        };

        var association = new Associations()
        {
            Name = "Engineering",
            Persons = new List<Person>()
        };

        await dbContext.Regions.AddAsync(region);
        await dbContext.Associations.AddAsync(association);
        await dbContext.SaveChangesAsync();

        var person = new Person()
        {
            FirstName = "Ala",
            LastName = "Bala",
            Age = 12,
            City = "Sofia",
            RegionId = region.Id,
            Associations = new List<Associations> { association }
        };

        await dbContext.Persons.AddAsync(person);
        await dbContext.SaveChangesAsync();

        var personFromDb = await dbContext.Persons.Where(p => p.FirstName == "Ali").ToListAsync();
    }
}
