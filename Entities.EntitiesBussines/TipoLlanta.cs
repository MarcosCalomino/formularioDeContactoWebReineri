using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.EntitiesBussines
{
    public class TipoLlanta
    {
        private int idTipoLlanta;
        private string descripcion;

        public int IdTipoLlanta { get => idTipoLlanta; set => idTipoLlanta = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

    }
}
