using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models;

public class Student
{
    [Required]
    [Key]
    public int StudentId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [StringLength(10)]
    public string? PhoneNumber { get; set; }

    [Required]
    public DateTime RegisteredOn { get; set; }

    public DateTime? Birthday { get; set; }

    //navigation prop - one sudent can have many courses
    public ICollection<Course> Courses { get; set; }

    //navigation prop - one sudent can have many homeworks
    public ICollection<Homework> Homeworks { get; set; }

}
