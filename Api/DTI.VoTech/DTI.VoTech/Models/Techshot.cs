using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DTI.VoTech.Models
{
    public class Techshot
    {
        public int TechshotId { get; set; }
        public DateTime DataInicio { get; set; }

        public int? EmpresaFk { get; set; }
    }
}