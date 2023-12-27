using System.ComponentModel.DataAnnotations;

namespace Farmucho.Models
{
    public class Inventario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public string? Droga { get; set; }
        [Required]
        public string? Vencimiento { get; set; }
        [Required]
        public string? Laboratorio { get; set; }
        [Required]
        public double PrecioCompra { get; set; }
        [Required]
        public double PrecioVenta { get; set; }
    }
}