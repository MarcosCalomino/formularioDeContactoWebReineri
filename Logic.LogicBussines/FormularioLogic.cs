using Data.DataBase;
using Entities.EntitiesBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.LogicBussines
{
    public class FormularioLogic
    {
        public TipoDisposicionDAO tdDAO { get; set; }
        public TipoLlantaDAO tlDAO { get; set; }
        public PedidoDAO pdAO { get; set; }
        public FormularioLogic()
        {
            tdDAO = new TipoDisposicionDAO();
            tlDAO = new TipoLlantaDAO();
            pdAO = new PedidoDAO();
        }
        public TipoDisposicion GetOneTD(int id)
        {
            try
            {
                    TipoDisposicion tipoDisposicion = tdDAO.GetOne(id);
                    if (tipoDisposicion == null)
                        throw new Exception("Error en la App. Consulte el estado de los servidores o comuniquese con el encargado");
                    return tipoDisposicion;   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TipoLlanta GetOneTL(int id)
        {
            try
            {
                TipoLlanta tipoLlanta = tlDAO.GetOne(id);
                if (tipoLlanta == null)
                    throw new Exception("Error en la App. Consulte el estado de los servidores o comuniquese con el encargado");
                return tipoLlanta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreatePedido(Pedido pedidoActual)
        {
            try
            {
                pdAO.CreatePedido(pedidoActual);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
