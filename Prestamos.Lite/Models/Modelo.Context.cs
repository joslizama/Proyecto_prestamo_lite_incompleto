﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prestamos.Lite.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Conexion : DbContext
    {
        public Conexion()
            : base("name=Conexion")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cuota> Cuotas { get; set; }
        public virtual DbSet<Prestamo> Prestamoes { get; set; }
        public virtual DbSet<Tipo_moneda> Tipo_moneda { get; set; }
        public virtual DbSet<Tipo_pago> Tipo_pago { get; set; }
        public virtual DbSet<tipo_usuario> tipo_usuario { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}