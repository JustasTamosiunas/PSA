using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class PostCenter
    {
        public int Id { get; set; }
        [DisplayName("Gatvė")]
        public string Street { get; set; }

        [DisplayName("Miestas")]
        public string City { get; set; }

        [DisplayName("Pastato numeris")]
        public string BuildingNo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [DisplayName("Pavadinimas")]
        public string Name { get; set; }
    }
}