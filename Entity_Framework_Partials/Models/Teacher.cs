using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework_Partials.Models
{
    /// <summary>
    /// The Model for Teachers. Should only be connected to Course.
    /// </summary>
    public class Teacher
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength =2, ErrorMessage = "The length of the firstname has to be between 2 to 20 characters.")]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "The length of the lastname has to be between 2 to 30 characters.")]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [Required]
        [Range(18, 100, ErrorMessage = "The age of the teacher has to be between 18 to 100 years old.")]
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

    }
}
