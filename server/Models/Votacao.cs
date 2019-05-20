using System;

namespace server.Models
{
    public class Votacao
    {
        public DateTime DataInicio { get; set; }

        public DateTime Duracao { get; set; }

        public Tema TemaVencedor { get; set; }


    }
}