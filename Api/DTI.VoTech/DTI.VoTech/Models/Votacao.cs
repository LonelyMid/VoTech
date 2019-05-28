using System;

namespace DTI.VoTech.Models
{
    public class Votacao
    {
        public int VotacaoId { get; set; }
        public DateTime DataInicio { get; set; }

        public DateTime Duracao { get; set; }

        public Tema TemaVencedor { get; set; }


    }
}