using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Labb4Models
{
    public class Interest
    {
        [Key]
        public int InterestID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Link>? Links { get; set; } = new List<Link>();

        [JsonIgnore]
        public virtual ICollection<Person>? Persons { get; set; } = new List<Person>();
    }
}
