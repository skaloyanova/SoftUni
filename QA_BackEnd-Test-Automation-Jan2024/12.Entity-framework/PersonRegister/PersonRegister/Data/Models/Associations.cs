using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegister.Data.Models;

public class Associations
{
    public int Id { get; set; }

    public string Name { get; set; }

    [InverseProperty("Associations")]
    public ICollection<Person> Persons { get; set; }
}
