namespace Farmucho.Models
{
    public class ItemFactura
    {
        public Inventario? Medicamento { get; set; }
        public int Cantidad { get; set; }
        public double Importe { get; set; }
        public ItemFactura(Inventario medicamento, int cantidad, double precioUnitario)
        {
            Medicamento = medicamento;
            Cantidad = cantidad;
            Importe = precioUnitario * cantidad;
        }
    }
}