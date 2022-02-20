using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Entities
{
    [Table("Cliente", Schema = "dbo")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required, StringLength(50)]
        public string Identificacion { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; }

        [Required, StringLength(100)]
        public string Apellido { get; set; }

        [Required, StringLength(100)]
        public string Telefono { get; set; }
    }
}
