using System.ComponentModel.DataAnnotations;

namespace AutoServiceWeb.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        public int Year { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        [Required]
        public string CustomerName { get; set; }

        public string Phone { get; set; }

        public string Color { get; set; }
    }
}