using System.ComponentModel.DataAnnotations;

namespace weatherapi.Models
{
    public class WeatherForecast
    {

        [Key]
        public int Id
        {
            get; set;
        }

        [Required]
        public int TemperatureC { get; set; }

        [Required]
        [MaxLength(255)]
        public string Summary { get; set; }
    }
}