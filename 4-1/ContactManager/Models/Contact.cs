using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage ="Please enter a first name")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "Please enter a last name")]
        public string Lname { get; set; }
        [Required(ErrorMessage = "Please enter a phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter an email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a category")]
        public string Category { get; set; }
    }
}
