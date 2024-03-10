using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegister.Data.Models;

public class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string City { get; set; }

    public int Age { get; set; }

    public int? RegionId { get; set; }

    //navigation property
    public Region Region { get; set; }

    [InverseProperty("Persons")]
    public ICollection<Associations> Associations { get; set; }

}
