using Eventmi.Infrastructure.Data.Contexts;
using Eventmi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventmi.Tests;

public class Helper
{
    public static bool CheckEventExists(string eventName)
    {
        //define DbContext options
        var options = new DbContextOptionsBuilder<EventmiContext>()
        .UseSqlServer("Server=.\\SQLEXPRESS;Database=Eventmi;Trusted_Connection=True;MultipleActiveResultSets=true")
        .Options;

        using var context = new EventmiContext(options);

        return context.Events.Any(e => e.Name == eventName);
    }

    public static async Task<Event> GetEventByIdAsync(int id)
    {
        var options = new DbContextOptionsBuilder<EventmiContext>()
            .UseSqlServer("Server=.\\SQLEXPRESS;Database=Eventmi;Trusted_Connection=True;MultipleActiveResultSets=true")
            .Options;

        using var context = new EventmiContext(options);

        return await context.Events.FirstOrDefaultAsync(e => e.Id == id);
    }

    public static async Task<Event> GetEventByNameAsync(string name)
    {
        var options = new DbContextOptionsBuilder<EventmiContext>()
            .UseSqlServer("Server=.\\SQLEXPRESS;Database=Eventmi;Trusted_Connection=True;MultipleActiveResultSets=true")
            .Options;

        using var context = new EventmiContext(options);

        return await context.Events.FirstOrDefaultAsync(e => e.Name == name);
    }
}
