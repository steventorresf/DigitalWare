using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Entities
{
    [Table("Factura", Schema = "dbo")]
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }

        [Required]
        public int NoFactura { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public DateTime FechaVenta { get; set; }
    }
}
