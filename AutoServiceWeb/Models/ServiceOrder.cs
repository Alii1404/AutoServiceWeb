using System;
using System.ComponentModel.DataAnnotations;

namespace AutoServiceWeb.Models
{
    public class ServiceOrder
    {
        public int Id { get; set; }

        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        [Required]
        public string ServiceType { get; set; }

        public string ProblemDescription { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Yeni";
    }
}