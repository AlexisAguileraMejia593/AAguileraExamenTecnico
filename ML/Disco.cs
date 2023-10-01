using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Disco
    {
        public int IdDisco { get; set; }
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public string GeneroMusical { get; set; } 
        public string Duracion { get; set; }
        public string Año { get; set; }
        public string Distribuidora { get; set; }
        public decimal Ventas { get; set; }
        public int Disponibilidad { get; set; }
        public string Imagen {  get; set; }
        public List<Object> Discos {  get; set; }
    }
}