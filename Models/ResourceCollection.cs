using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TroubleInParadise.Models
{
    public class ResourceCollection
    {
        public int Id {  get; set; }
        [ForeignKey("ResourceId")]
        public virtual ICollection<Resource>? Resources {  get; set; }
    }
}
