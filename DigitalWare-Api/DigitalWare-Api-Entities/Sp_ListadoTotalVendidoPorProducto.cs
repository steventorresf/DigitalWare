using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Entities
{
    public class Sp_ListadoTotalVendidoPorProducto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal TotalVendido { get; set; }
    }
}
