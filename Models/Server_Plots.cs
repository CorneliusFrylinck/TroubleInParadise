namespace TroubleInParadise.Models
{
    public class Server_Plots
    {
        public int Id { get; set; }
        public int ServerId { get; set; }
        public Plot_Type PlotType { get; set; }
        public Location startLocation { get; set; }
        public Location endLocation { get; set; }
    }
}
