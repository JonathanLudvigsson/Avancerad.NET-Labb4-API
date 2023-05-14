using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Labb4Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 20 characters long.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = " Last name must be between 2 and 20 characters long.")]
        public string LastName { get; set; }

        [Range(13, 75, ErrorMessage = "Age must be in range of 13 to 75.")]
        public int Age { get; set; }

        [StringLength(15, ErrorMessage = "Phone number must be 15 characters or shorter.")]
        public string Phone { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [JsonIgnore]
        public virtual ICollection<Interest>? Interests { get; set; } = new List<Interest>();

    }
}