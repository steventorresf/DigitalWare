using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Entities
{
    [Table("Secuencia", Schema = "dbo")]
    public class Secuencia
    {
        [Key]
        public int IdSecuencia { get; set; }

        [Required, StringLength(50)]
        public string CodigoSecuencia { get; set; }

        [Required, StringLength(200)]
        public string DescripcionSecuencia { get; set; }

        [Required]
        public int NoSecuencia { get; set; }
    }
}
