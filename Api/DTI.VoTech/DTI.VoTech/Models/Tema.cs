namespace DTI.VoTech.Models
{
    public class Tema
    {
        public int TemaId { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public int? Votos { get; set; }

        public int? TechshotFk { get; set; }
    }
}