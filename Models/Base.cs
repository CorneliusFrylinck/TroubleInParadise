using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TroubleInParadise.Models
{
    public class Base
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        [Required]
        public string Name {  get; set; }
        public int LocationId {  get; set; }
        [ForeignKey("BaseId")]
        public virtual ICollection<Building>? Buildings {  get; set; }
        [ForeignKey("BaseId")]
        public virtual ResourceCollection Resources {  get; set; }
        [ForeignKey("EventId")]
        public virtual ICollection<Event> Events { get; set; }
    }
}
