using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Entities
{
    [Table("Producto", Schema = "dbo")]
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        public decimal ValorUnitario { get; set; }
    }
}
