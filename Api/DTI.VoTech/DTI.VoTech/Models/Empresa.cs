using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTI.VoTech.Models
{
    public class Empresa
    {
        public int EmpresaId { get; set; }

        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public List<Techshot>? TechshotsRealizadas { get; set; }
    }
}
