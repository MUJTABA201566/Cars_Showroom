using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace Cars_Showroom.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public int Model { get; set; }
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public int DrivingCounter { get; set; }
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public int Price { get; set; }
        [Required(ErrorMessage = "هذا الحقل اجباري")]
        public string CarStatus { get; set; }
        public bool Availability { get; set; } = true;
        

    }
}

