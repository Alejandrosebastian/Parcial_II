using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Parcial_II.Models;

namespace Parcial_II.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Parcial_II.Models.Categoria_Laboral> Categoria_Laboral { get; set; }

        public DbSet<Parcial_II.Models.Ciudad> Ciudad { get; set; }

        public DbSet<Parcial_II.Models.Cliente> Cliente { get; set; }

        public DbSet<Parcial_II.Models.Contrato> Contrato { get; set; }

        public DbSet<Parcial_II.Models.Empleado> Empleado { get; set; }

        public DbSet<Parcial_II.Models.Inmuebles> Inmuebles { get; set; }

        public DbSet<Parcial_II.Models.Parroquia> Parroquia { get; set; }

        public DbSet<Parcial_II.Models.Propietario> Propietario { get; set; }

        public DbSet<Parcial_II.Models.Rol> Rol { get; set; }

        public DbSet<Parcial_II.Models.Sucur_emple> Sucur_emple { get; set; }

        public DbSet<Parcial_II.Models.Sucursal> Sucursal { get; set; }

        public DbSet<Parcial_II.Models.Tipopago> Tipopago { get; set; }

        public DbSet<Parcial_II.Models.Tipos_inmu> Tipos_inmu { get; set; }

        public DbSet<Parcial_II.Models.Usuario> Usuario { get; set; }
    }
}
