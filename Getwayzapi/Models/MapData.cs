
namespace Getwayzapi.Models
{
    public class MapData
    {
        private string? district;
        private string? state;
        private string? updated_by;
        private string? publicPlace;
        public string lane = "My vill";


        public Guid Id { get; set; }

        public string? PlotNo { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        // public string? PostCode { get; private set; }
        //   public string? Village { get; private set; }
        public string? Street { get; set; }
        public string? Town { get; set; }
        public string? PostCode { get; set; }

        public string? Village { get; set; }


    }
}




