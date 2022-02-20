using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Entities
{
    [Table("FacturaDetalle", Schema = "dbo")]
    public class FacturaDetalle
    {
        [Key]
        public int IdFacturaDetalle { get; set; }

        [Required]
        public int IdFactura { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        public decimal Cantidad { get; set; }

        [Required]
        public decimal ValorUnitario { get; set; }
    }
}
