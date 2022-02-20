using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Dto
{
    public class FacturaDto
    {
        public int IdFactura { get; set; }
        public int NoFactura { get; set; }
        public int IdCliente { get; set; }
        public string? NombreCliente { get; set; }
        public DateTime FechaVenta { get; set; }
        public IList<FacturaDetalleDto> FacturaDetalle { get; set; }
    }

    public class FacturaDetalleDto
    {
        public int IdFacturaDetalle { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public string? NombreProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal? ValorTotal { get; set; }
    }
}
