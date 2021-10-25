using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TroubleInParadise.Models
{
    public class Server
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public DateTime Created {  get; set; }
        public DateTime ReleaseDate {  get; set; }
        public DateTime CloseDate {  get; set; }
#nullable enable
        [ForeignKey("ServerId")]
        public virtual ICollection<Player>? Players {  get; set; }
        [ForeignKey("ServerId")]
        public virtual ICollection<Server_Plots>? server_Plots { get; set; }

    }
    [NotMapped]
    public class PlayerServer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CloseDate { get; set; }
        public bool HasPlayer { get; set; }

    }
}
