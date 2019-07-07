using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Partials.Models
{
    /// <summary>
    /// The Model for all Students. Only used for Course.
    /// </summary>
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Firstname")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Students firstname has to be between 2 to 20 characters long.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Students lastname has to be between 2 to 30 characters long.")]
        public string LastName { get; set; }

        [Required]
        [Range(6, 100, ErrorMessage = "Students age has to be between 6 to 100 years old.")]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phonenumber")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "The teachers phonenumber has to be between 3 to 15 characters long.")]
        public string PhoneNumber { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();

    }
}
