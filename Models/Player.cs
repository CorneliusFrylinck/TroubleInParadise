using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TroubleInParadise.Data;

namespace TroubleInParadise.Models
{
    public class Player : IValidatableObject
    {
        public int Id {  get; set; }
        [Required]
        public string Name {  get; set; }
        public int ServerId {  get; set; }
        public int UserId {  get; set; }
        public DateTime Last_Seen {  get; set; }
        public DateTime Last_Updated {  get; set; }
        public DateTime Created {  get; set; }
        [ForeignKey("BaseId")]
        public virtual ICollection<Base>? Bases {  get; set; }
        [ForeignKey("EventId")]
        public virtual ICollection<Event>? Events {  get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var _context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            List<Player> players = _context.player.Where(p => p.ServerId == ServerId && p.Name == Name).ToList<Player>();

            if (players.Count > 0)
            {
                yield return new ValidationResult(
                    $"Playername is already taken, please try again.");
            }
        }
    }
}
