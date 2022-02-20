using DigitalWare_Api_Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare_Api_Infrastructure
{
    public class DbContextApi : DbContext
    {
        public DbContextApi(DbContextOptions<DbContextApi> options) : base(options)
        {
        }

        #region DbSet
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<FacturaDetalle> FacturasDetalle { get; set; }
        public virtual DbSet<Secuencia> Secuencias { get; set; }
        #endregion

        #region Consultas
        public virtual DbSet<Sp_ListadoClientesNoMayores> Sp_ListadoClientesNoMayores { get; set; }
        public virtual DbSet<Sp_ListadoPreciosProductos> Sp_ListadoPreciosProductos { get; set; }
        public virtual DbSet<Sp_ListadoProductosExistenciaMinima> Sp_ListadoProductosExistenciaMinima { get; set; }
        public virtual DbSet<Sp_ListadoTotalVendidoPorProducto> Sp_ListadoTotalVendidoPorProducto { get; set; }
        public virtual DbSet<Sp_UltimaFechaCompraCliente> Sp_UltimaFechaCompraCliente { get; set; }
        #endregion
    }
}
