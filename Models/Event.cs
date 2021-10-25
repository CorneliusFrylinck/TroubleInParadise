using System;

namespace TroubleInParadise.Models
{
    public class Event
    {
        public int Id {  get; set; }
        public DateTime TimeStamp {  get; set; }
        public virtual Effect? Effect { get; set; }
        public bool IsPermanent {  get; set; }
    }
}
