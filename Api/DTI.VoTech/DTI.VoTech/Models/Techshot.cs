using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DTI.VoTech.Models
{
    public class Techshot
    {
        public int TechshotId { get; set; }

        public int TemaId { get; set; }
        public virtual List Temas { get; set; }

        public DateTime DataInicio { get; set; }
    }
}