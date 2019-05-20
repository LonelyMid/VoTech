using System;

namespace VoTech.Models
{
    public class Techshots
    {
        /* [ForeignKey] */
        public Tema Temas { get; set; }

        public DateTime DataInicio { get; set; }
    }
}