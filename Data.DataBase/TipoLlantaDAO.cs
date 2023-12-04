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
    public class TipoLlantaDAO : Adapter
    {
        public TipoLlanta GetOne(int v)
        {
            TipoLlanta tl = null;
            try
            {
                OpenConnection();
                SqlCommand comando = new SqlCommand("sp_GetOneTL", sqlConn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@ID", SqlDbType.Int).Value = v;
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    tl = new TipoLlanta();
                    tl.IdTipoLlanta = (int)dr["IdTipoLlanta"];
                    tl.Descripcion = (string)dr["descripcion"];
                }
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
            return tl;
        }
    }
}
