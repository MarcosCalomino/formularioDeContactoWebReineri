using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.EntitiesBussines
{
    public class Pedido
    {
        private int idPedido;
        private string nombreCliente;
        private string localidad;
        private string email;
        private string telefono;
        private decimal capacidadDeCarga;
        private decimal trochaDelEje;
        private string datosAdicionales;
        private TipoDisposicion tipoDisposicion;
        private TipoLlanta tipoLlanta;

        public TipoDisposicion TipoDisposicion { get => tipoDisposicion; set => tipoDisposicion = value; }
        public TipoLlanta TipoLlanta { get => tipoLlanta; set => tipoLlanta = value; }
        public int IdPedido { get => idPedido; set => idPedido = value; }
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        public string Email { get => email; set => email = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public decimal CapacidadDeCarga { get => capacidadDeCarga; set => capacidadDeCarga = value; }
        public decimal TrochaDelEje { get => trochaDelEje; set => trochaDelEje = value; }
        public string DatosAdicionales { get => datosAdicionales; set => datosAdicionales = value; }
    }
}
