using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ML
{
    public class Disco
    {
        public int IdDisco { get; set; }
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public string GeneroMusical { get; set; }
        public TimeSpan Duracion { get; set; }
        public DateTime Año { get; set; }
        public string Distribuidora { get; set; }
        public decimal Ventas { get; set; }
        public bool Disponibilidad { get; set; }
        public string Imagen { get; set; }
        public List<object> Discos { get; set; }
        // Propiedad adicional para mostrar 'Disponibilidad' como "SI" o "NO"
        [DisplayName("Disponible")]
        public string DisponibilidadTexto
        {
            get
            {
                return Disponibilidad ? "SI" : "NO";
            }
            set
            {
                // Si el valor es "SI", establece Disponibilidad en true; de lo contrario, en false
                if (value == "SI")
                {
                    Disponibilidad = true;
                }
                else if (value == "NO")
                {
                    Disponibilidad = false;
                }
                // Puedes agregar más lógica aquí si es necesario
            }
        }
    }
}