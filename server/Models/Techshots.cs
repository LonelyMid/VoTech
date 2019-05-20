using System;

namespace VoTech.Models
{
    public class Techshots
    {
        /* [ForeignKey] */
        public int TemaFK { get; set; }

        public DateTime DataInicio { get; set; }
    }
}