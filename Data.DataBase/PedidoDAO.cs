using Entities.EntitiesBussines;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataBase
{
    public class PedidoDAO : Adapter
    {
        public void CreatePedido(Pedido pedidoActual)
        {
            try
            {
                OpenConnection();
                SqlCommand comando = new SqlCommand("sp_createPedido", sqlConn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@nombreCliente", SqlDbType.VarChar).Value = pedidoActual.NombreCliente;
                comando.Parameters.Add("@localidad", SqlDbType.VarChar).Value = pedidoActual.Localidad;
                comando.Parameters.Add("@email", SqlDbType.VarChar).Value = pedidoActual.Email;
                comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = pedidoActual.Telefono;
                comando.Parameters.Add("@capacidadDeCarga", SqlDbType.Decimal).Value = pedidoActual.CapacidadDeCarga;
                comando.Parameters.Add("@trochaDelEje", SqlDbType.Decimal).Value = pedidoActual.TrochaDelEje;
                comando.Parameters.Add("@datosAdicionales", SqlDbType.VarChar).Value = pedidoActual.DatosAdicionales;
                comando.Parameters.Add("@idTipoDisposicion", SqlDbType.Int).Value = pedidoActual.TipoDisposicion.IdTipoDisposicion;
                comando.Parameters.Add("@idTipoLlanta", SqlDbType.Int).Value = pedidoActual.TipoLlanta.IdTipoLlanta;
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error relacionado con la red o el servidor, verifique su conexion a internet. Pruebe nuevamente", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
