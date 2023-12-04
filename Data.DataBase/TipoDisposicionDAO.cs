using Entities.EntitiesBussines;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataBase;
using System.Security.Cryptography;

namespace Data.DataBase
{
    public class TipoDisposicionDAO: Adapter
    {
        public TipoDisposicion GetOne(int v)
        {
            TipoDisposicion td = null;
            try
            {
                OpenConnection();
                SqlCommand comando = new SqlCommand("sp_GetOneTD", sqlConn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("@ID", SqlDbType.Int).Value = v;
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    td = new TipoDisposicion();
                    td.IdTipoDisposicion = (int)dr["IdTipoDisposicion"];
                    td.Descripcion = (string)dr["descripcion"];
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
            return td;
        }
    }
}
