﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AppDomain;

namespace Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FootbalEntities : DbContext
    {
        public FootbalEntities()
            : base("name=FootbalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Partido> Partidos { get; set; }
        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<Temporada> Temporadas { get; set; }
        public virtual DbSet<Liga> Ligas { get; set; }
    }
}
