using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.EntitiesBussines
{
    public class TipoDisposicion
    {
        private int idTipoDisposicion;
        private string descripcion;

        public int IdTipoDisposicion { get => idTipoDisposicion; set => idTipoDisposicion = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
