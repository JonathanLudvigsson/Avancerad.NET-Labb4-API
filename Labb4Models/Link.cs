using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Labb4Models
{
    public class Link
    {
        [Key]
        public int LinkID { get; set; }

        public string URL { get; set; }
        
        public int PersonID { get; set; }

        public int InterestID { get; set; }

        [JsonIgnore]
        public virtual Person? LinkPerson { get; set; }

        [JsonIgnore]
        public virtual Interest? LinkInterest { get; set; }
    }
}
