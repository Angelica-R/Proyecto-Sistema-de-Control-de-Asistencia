using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoGrupal.Entidad
{
    public class ClsHojaEntidad
    {
        public int ID_Asistencia { set; get; }
        public int ID_Trabajador { set; get; }
        public string Estado { set; get; }
        public string Hora { set; get; }
    }
}
