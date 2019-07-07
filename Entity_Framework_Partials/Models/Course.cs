using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Partials.Models
{
    /// <summary>
    /// The main "connector" between all the models.
    /// </summary>
    public class Course
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "The name of the course has to be between 2 to 40 characters long.")]
        public string Name { get; set; }

        [Required]
        [Range(50, 500)]
        [Display(Name = "Course-points")]
        public int Points { get; set; }

        public string Description { get; set; }

        public Grades Grade { get; set; }

        public List<Student> Students { get; set; }

        public List<Assignment> Assignments { get; set; }

        public Teacher Teacher { get; set; }
        public enum Grades { A, B, C, D, E, F };
    }
}
