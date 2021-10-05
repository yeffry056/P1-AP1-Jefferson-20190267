using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_AP1_Jefferson_20190267.Entidades
{
    public class Aportes
    {
       [Key]
        public int AporteId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Nombre { get; set; }
        public string Concepto { get; set; }
        public int Monto { get; set; }

    }
}
