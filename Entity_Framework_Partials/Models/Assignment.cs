using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Partials.Models
{
    /// <summary>
    /// Should only exist inside a Course.
    /// </summary>
    public class Assignment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The name of the assignment has to be between 2 to 50 characters long.")]
        public string Name { get; set; }

        public Grades Grade { get; set; }

        public string Description { get; set; }

        public Course Course { get; set; }

        public enum Grades { A, B, C, D, E, F };
    }
}
