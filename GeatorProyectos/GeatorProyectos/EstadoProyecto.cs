using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeatorProyectos
{
    public enum EstadoProyecto
    {
        Planificacion,
        EnDesarrollo,
        EnPruebas,
        Completado,
        Cancelado
    }

    public enum TipoDesarrollo
    {
        Web,
        Movil
    }
}
