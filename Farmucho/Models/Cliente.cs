using System.ComponentModel.DataAnnotations;

namespace Farmucho.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Apellido { get; set; }
        public int Telefono { get; set; }
        public string? Mail { get; set; }
        public int Cuit { get; set; }
    }
}