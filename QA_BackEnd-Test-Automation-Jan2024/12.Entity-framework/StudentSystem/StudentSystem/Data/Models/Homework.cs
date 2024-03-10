using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models;
public class Homework
{
    [Required]
    [Key]
    public int HomeworkId { get; set; }

    [Required]
    public string Content { get; set; }

    public enum ContentTypeEnum
    {
        Application,
        Pdf,
        Zip
    }

    [Required]
    public ContentTypeEnum ContentType { get; set; }

    [Required]
    public DateTime SubmissionTime { get; set; }

    //foreign key
    public int StudentId { get; set; }

    //navigation prop - one homework, one student
    public Student Student { get; set; }

    //foreign key
    public int CourseId { get; set; }

    //navigation prop - one homework, one course
    public Course Course { get; set; }
}

