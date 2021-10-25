using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TroubleInParadise.Models
{
    public class Building
    {
        public int Id {  get; set; }
        public int BaseId {  get; set; }
        public int BuildingTypeID {  get; set; }
        public virtual Effect? Effect {  get; set; }
        [DefaultValue(0)]
        public int Level {  get; set; }
        [ForeignKey("EventId")]
        public virtual ICollection<Event> Events { get; set; }
    }
}
