using System.ComponentModel.DataAnnotations;

namespace Details.Models
{
    public class Person
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public String FirstName {  get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required]
        public String Address { get; set; }

        [Required]
        [EmailAddress]
        public String Email {  get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public long PhoneNumber { get; set; }
    }
}
