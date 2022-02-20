using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Entities
{
    public class Sp_ListadoClientesNoMayores
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
