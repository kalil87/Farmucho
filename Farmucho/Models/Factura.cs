namespace Farmucho.Models
{
    public class Factura
    {
        public static int Id { get; set; }
        public Cliente? ClienteFac { get; set; }
        public List<ItemFactura> ItemsFactura { get; set; }
        public int NumFac { get; set; }
        public double ImporteTotal { get; set; }
        public Factura(Cliente cliente, List<ItemFactura> itemsFactura)
        {
            NumFac = ++Id;
            ClienteFac = cliente;
            ItemsFactura = itemsFactura;
            ImporteTotal += CalcularTotal();
        }
        public Factura(List<ItemFactura> itemsFactura)
        {
            Id++;
            NumFac = Id;
            ItemsFactura = itemsFactura;
            ImporteTotal += CalcularTotal();
        }
        public double CalcularTotal()
        {
            double total = 0;
            foreach (ItemFactura itemFactura in ItemsFactura)
            {
                total += itemFactura.Importe;
            }
            return total;
        }
    }
}