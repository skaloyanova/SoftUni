using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models;

public class Course
{
    [Required]
    [Key]
    public int CourseId { get; set; }

    [Required]
    [MaxLength(80)]
    public string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")] // specifying precision and scale
    public decimal Price { get; set; }

    //navigation prop - one course can have many students
    public ICollection<Student> Students { get; set; }

    //navigation prop - one course can have many resources
    public ICollection<Resource> Resources { get; set; }

    //navigation prop - one course can have many homeworks
    public ICollection<Homework> Homeworks { get; set; }
}
