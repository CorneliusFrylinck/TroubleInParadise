using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TroubleInParadise.Models
{
    public class BuildingType
    {
        public int Id {  get; set; }
        [Required]
        public string Name {  get; set; }
        public string? Description {  get; set; }
        public virtual ICollection<Building>? Buildings {  get; set; }
    }
}
