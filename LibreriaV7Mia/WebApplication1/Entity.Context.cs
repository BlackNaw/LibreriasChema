﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Libreria_V6
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class libreriavsEntities : DbContext
    {
        public libreriavsEntities()
            : base("name=libreriavsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tema> tema { get; set; }
        public virtual DbSet<tfactura> tfactura { get; set; }
        public virtual DbSet<tlibro> tlibro { get; set; }
        public virtual DbSet<tlineafactura> tlineafactura { get; set; }
        public virtual DbSet<tusuario> tusuario { get; set; }
    }
}
