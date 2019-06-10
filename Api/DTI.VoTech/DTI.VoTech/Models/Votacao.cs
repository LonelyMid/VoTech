using System;
using System.Collections.Generic;

namespace DTI.VoTech.Models
{
    public class Votacao
    {
        public int VotacaoId { get; set; }

        public Tema TemaVencedor { get; set; }

        public List<Tema> TemasPaticipantes { get; set; }

        public Techshot TechshotVigente { get; set; }

        public int? Votos { get; set; }
    }
}