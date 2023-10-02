﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MixUpEntities : DbContext
    {
        public MixUpEntities()
            : base("name=MixUpEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Disco> Disco { get; set; }
    
        public virtual int DiscoAdd(string titulo, string artista, string generoMusical, string duracion, string año, string distribuidora, Nullable<decimal> ventas, Nullable<int> disponibilidad, string imagen)
        {
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            var artistaParameter = artista != null ?
                new ObjectParameter("Artista", artista) :
                new ObjectParameter("Artista", typeof(string));
    
            var generoMusicalParameter = generoMusical != null ?
                new ObjectParameter("GeneroMusical", generoMusical) :
                new ObjectParameter("GeneroMusical", typeof(string));
    
            var duracionParameter = duracion != null ?
                new ObjectParameter("Duracion", duracion) :
                new ObjectParameter("Duracion", typeof(string));
    
            var añoParameter = año != null ?
                new ObjectParameter("Año", año) :
                new ObjectParameter("Año", typeof(string));
    
            var distribuidoraParameter = distribuidora != null ?
                new ObjectParameter("Distribuidora", distribuidora) :
                new ObjectParameter("Distribuidora", typeof(string));
    
            var ventasParameter = ventas.HasValue ?
                new ObjectParameter("Ventas", ventas) :
                new ObjectParameter("Ventas", typeof(decimal));
    
            var disponibilidadParameter = disponibilidad.HasValue ?
                new ObjectParameter("Disponibilidad", disponibilidad) :
                new ObjectParameter("Disponibilidad", typeof(int));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DiscoAdd", tituloParameter, artistaParameter, generoMusicalParameter, duracionParameter, añoParameter, distribuidoraParameter, ventasParameter, disponibilidadParameter, imagenParameter);
        }
    
        public virtual int DiscoDelete(Nullable<int> idDisco)
        {
            var idDiscoParameter = idDisco.HasValue ?
                new ObjectParameter("IdDisco", idDisco) :
                new ObjectParameter("IdDisco", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DiscoDelete", idDiscoParameter);
        }
    
        public virtual ObjectResult<DiscoGetById_Result> DiscoGetById(Nullable<int> idDisco)
        {
            var idDiscoParameter = idDisco.HasValue ?
                new ObjectParameter("IdDisco", idDisco) :
                new ObjectParameter("IdDisco", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DiscoGetById_Result>("DiscoGetById", idDiscoParameter);
        }
    
        public virtual int DiscoUpdate(Nullable<int> idDisco, string titulo, string artista, string generoMusical, string duracion, string año, string distribuidora, Nullable<decimal> ventas, Nullable<int> disponibilidad, string imagen)
        {
            var idDiscoParameter = idDisco.HasValue ?
                new ObjectParameter("IdDisco", idDisco) :
                new ObjectParameter("IdDisco", typeof(int));
    
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            var artistaParameter = artista != null ?
                new ObjectParameter("Artista", artista) :
                new ObjectParameter("Artista", typeof(string));
    
            var generoMusicalParameter = generoMusical != null ?
                new ObjectParameter("GeneroMusical", generoMusical) :
                new ObjectParameter("GeneroMusical", typeof(string));
    
            var duracionParameter = duracion != null ?
                new ObjectParameter("Duracion", duracion) :
                new ObjectParameter("Duracion", typeof(string));
    
            var añoParameter = año != null ?
                new ObjectParameter("Año", año) :
                new ObjectParameter("Año", typeof(string));
    
            var distribuidoraParameter = distribuidora != null ?
                new ObjectParameter("Distribuidora", distribuidora) :
                new ObjectParameter("Distribuidora", typeof(string));
    
            var ventasParameter = ventas.HasValue ?
                new ObjectParameter("Ventas", ventas) :
                new ObjectParameter("Ventas", typeof(decimal));
    
            var disponibilidadParameter = disponibilidad.HasValue ?
                new ObjectParameter("Disponibilidad", disponibilidad) :
                new ObjectParameter("Disponibilidad", typeof(int));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DiscoUpdate", idDiscoParameter, tituloParameter, artistaParameter, generoMusicalParameter, duracionParameter, añoParameter, distribuidoraParameter, ventasParameter, disponibilidadParameter, imagenParameter);
        }
    
        public virtual ObjectResult<DiscoGetAll_Result> DiscoGetAll(string titulo, string artista)
        {
            var tituloParameter = titulo != null ?
                new ObjectParameter("Titulo", titulo) :
                new ObjectParameter("Titulo", typeof(string));
    
            var artistaParameter = artista != null ?
                new ObjectParameter("Artista", artista) :
                new ObjectParameter("Artista", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DiscoGetAll_Result>("DiscoGetAll", tituloParameter, artistaParameter);
        }
    }
}
