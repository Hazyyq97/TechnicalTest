using System.ComponentModel.DataAnnotations;

namespace TechnicalTest.Models
{
    public class NumberDto
    {
        [Required]
        [Range(0, 999999999)]
        public double Number { get; set; }
    }
}
