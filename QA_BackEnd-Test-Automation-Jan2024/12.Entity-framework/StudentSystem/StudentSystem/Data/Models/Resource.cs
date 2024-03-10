using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models;

public class Resource
{
    [Required]
    [Key]
    public int ResourceId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    public string Url { get; set; }

    public enum ResourceTypeEnum
    {
        Video,
        Presentation,
        Document,
        Other
    }

    [Required]
    public ResourceTypeEnum ResourceType { get; set; }

    //foreign key
    [Required]
    public int CourseId { get; set; }

    //navigation prop - one resource, one course
    public Course Course { get; set; }
}

