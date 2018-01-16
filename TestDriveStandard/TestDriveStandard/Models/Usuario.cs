using System;
using System.Collections.Generic;
using System.Text;

namespace TestDriveStandard.Models
{
    public class Usuario
    {
        public string nome { get; set; }
        public string email { get; set; }

    }

    public class ResultadoLogin
    {
        public Usuario usuario { get; set; }
    }
}
