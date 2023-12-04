using Entities.EntitiesBussines;
using Logic.LogicBussines;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Optimization;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WebApplication1
{
    public partial class Index : System.Web.UI.Page
    {
        private Pedido pedidoActual;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["pedidoActual"] = new Pedido(); //Este bloque de código se ejecuta solo en la carga inicial de la página
                Session["Enviado"] = false;
            }
            else
            {
                pedidoActual = (Pedido)Session["pedidoActual"];//Este bloque de código se ejecuta en los postbacks(acciones del usuario que generan envíos al servidor)              
            }
        }

        #region PAGINA1
        protected void nextButtonPage1_Click(object sender, EventArgs e)
        {
            if (ValiarPage1())
            {
                LimpiarPage1();
                pedidoActual.NombreCliente = nombreTextBox.Text;
                pedidoActual.Localidad = localidadTextBox.Text;
                pedidoActual.Email = emailTextBox.Text;
                pedidoActual.Telefono = telefonoTextBox.Text;

                nombreNAV.InnerText = pedidoActual.NombreCliente;
                telefonoNAV.InnerText = pedidoActual.Telefono;
                emailNAV.InnerText = pedidoActual.Email;
                localidadNAV.InnerHtml = pedidoActual.Localidad;

                multiView.ActiveViewIndex = 1;
            }
        }

        private void LimpiarPage1()
        {
            lblErrorNombre.InnerText = "";
            lblErrorLocalidad.InnerText = "";
            lblErrorEmail.InnerText = "";
            lblErrorTelefono.InnerText = "";
        }

        private bool ValiarPage1()
        {
            if (string.IsNullOrEmpty(nombreTextBox.Text))
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Por favor, completa el campo Nombre.');", true);
                lblErrorNombre.InnerText = "Por favor, complete el campo Nombre.";
                return false;
            }
            else if (string.IsNullOrEmpty(localidadTextBox.Text))
            {
                lblErrorNombre.InnerText = "";
                lblErrorLocalidad.InnerText = "Por favor, complete el campo Localidad.";
                return false;
            }
            else if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                lblErrorLocalidad.InnerText = "";
                lblErrorEmail.InnerText = "Por favor, complete el campo Email.  No deje espacios en blanco";
                return false;
            }
            else if (!IsEmail(emailTextBox.Text))
            {
                lblErrorEmail.InnerText = "";
                lblErrorEmail.InnerText = "Formato incorrecto";
                return false;
            }
            else if (string.IsNullOrWhiteSpace(telefonoTextBox.Text))
            {
                lblErrorEmail.InnerText = "";
                lblErrorTelefono.InnerText = "Por favor, complete el campo Telefono. No deje espacios en blanco";
                return false;
            }
            else if (!IsNumeric(telefonoTextBox.Text))
            {
                telefonoTextBox.Text = "";
                lblErrorTelefono.InnerText = "El telefono debe ser un numero.";
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region PAGINA2
        protected void nextButtonPage2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarPage2())
                {
                    TipoDisposicion tipoDisposicionActual = null;
                    lblErrorPagina2.InnerText = "";
                    if (CheckBox1.Checked)
                        tipoDisposicionActual = new FormularioLogic().GetOneTD(1);

                    if (CheckBox2.Checked)
                        tipoDisposicionActual = new FormularioLogic().GetOneTD(2);

                    if (CheckBox3.Checked)
                        tipoDisposicionActual = new FormularioLogic().GetOneTD(3);

                    if (CheckBox4.Checked)
                        tipoDisposicionActual = new FormularioLogic().GetOneTD(4);

                    if (CheckBox5.Checked)
                        tipoDisposicionActual = new FormularioLogic().GetOneTD(5);

                    if (CheckBox6.Checked)
                        tipoDisposicionActual = new FormularioLogic().GetOneTD(6);

                    pedidoActual.TipoDisposicion = tipoDisposicionActual;
                    tipoDisposicionNAV.InnerHtml = pedidoActual.TipoDisposicion.Descripcion;
                    multiView.ActiveViewIndex = 2;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error_view.aspx");
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", ex.Message, true);
            }
        }

        private bool ValidarPage2()
        {
            if (!CheckBox1.Checked &&
                !CheckBox2.Checked &&
                !CheckBox3.Checked &&
                !CheckBox4.Checked &&
                !CheckBox5.Checked &&
                !CheckBox6.Checked)
            {
                lblErrorPagina2.InnerText = "Seleccione una opcion.";
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void previusButtonPage2_Click(object sender, EventArgs e)
        {
            nombreTextBox.Text = pedidoActual.NombreCliente;
            localidadTextBox.Text = pedidoActual.Localidad;
            emailTextBox.Text = pedidoActual.Email;
            telefonoTextBox.Text = pedidoActual.Telefono;
            lblErrorPagina2.InnerText = "";
            multiView.ActiveViewIndex = 0;
        }
        #endregion

        #region PAGINA3
        protected void nextButtonPage3_Click(object sender, EventArgs e)
        {
            if (ValidarPage3())
            {
                if (!decimal.TryParse(txtCarga.Text, out decimal carga))
                {
                    lblErrorCarga.InnerHtml = "El valor ingresado en el campo Carga no es un número válido.";
                }
                else
                {
                    pedidoActual.CapacidadDeCarga = carga;
                    cargaNAV.InnerText = Convert.ToDecimal(pedidoActual.CapacidadDeCarga).ToString();
                    multiView.ActiveViewIndex = 3;
                }
            }
        }

        private bool ValidarPage3()
        {
            if (string.IsNullOrWhiteSpace(txtCarga.Text))
            {
                lblErrorCarga.InnerHtml = "Por favor, complete el campo Carga.";
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void previusButtonPage3_Click(object sender, EventArgs e)
        {
            lblErrorCarga.InnerHtml = "";
            multiView.ActiveViewIndex = 1;
        }
        #endregion

        #region PAGINA4
        protected void nextButtonPage4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarPage4())
                {
                    TipoLlanta tipoLlanta = null;
                    lblErrorPagina4.InnerText = "";
                    if (CheckBox7.Checked)
                        tipoLlanta = new FormularioLogic().GetOneTL(1);

                    if (CheckBox8.Checked)
                        tipoLlanta = new FormularioLogic().GetOneTL(2);

                    pedidoActual.TipoLlanta = tipoLlanta;
                    tipoLlantasNAV.InnerText = pedidoActual.TipoLlanta.Descripcion;
                    multiView.ActiveViewIndex = 4;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error_view.aspx");
            }
        }

        private bool ValidarPage4()
        {
            if (!CheckBox7.Checked && !CheckBox8.Checked)
            {
                lblErrorPagina4.InnerText = "Seleccione una opcion.";
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void previusButtonPage4_Click(object sender, EventArgs e)
        {
            txtCarga.Text = Convert.ToDecimal(pedidoActual.CapacidadDeCarga).ToString();
            lblErrorPagina4.InnerText = "";
            lblErrorCarga.InnerText = "";
            multiView.ActiveViewIndex = 2;
        }

        protected void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            UncheckOtherCheckBoxesPage4(checkBox);
        }

        private void UncheckOtherCheckBoxesPage4(CheckBox currentCheckBox)
        {
            // Desmarca todos los demás CheckBox excepto el actual
            foreach (Control control in view4.Controls)
            {
                if (control is CheckBox checkBox && checkBox != currentCheckBox)
                {
                    checkBox.Checked = false;
                }
            }
        }
        #endregion

        #region PAGINA5
        protected void nextButtonPage5_Click(object sender, EventArgs e)
        {
            if (ValidarPage5())
            {
                if (!decimal.TryParse(txtTrochaDelEje.Text, out decimal trocha))
                {
                    lblErrorTrocha.InnerHtml = "El valor ingresado en el campo Trocha del eje no es un número válido.";
                }
                else
                {
                    pedidoActual.TrochaDelEje = trocha;
                    trochaNAV.InnerText = Convert.ToDecimal(pedidoActual.TrochaDelEje).ToString();
                    multiView.ActiveViewIndex = 5;
                }
            }
        }

        private bool ValidarPage5()
        {
            if (string.IsNullOrWhiteSpace(txtTrochaDelEje.Text))
            {
                lblErrorTrocha.InnerHtml = "Por favor, complete el campo Trocha del eje.";
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void previusButtonPage5_Click(object sender, EventArgs e)
        {
            lblErrorTrocha.InnerHtml = "";
            multiView.ActiveViewIndex = 3;
        }
        #endregion

        #region PAGINA6
        protected void nextButtonPage6_Click(object sender, EventArgs e)
        {
            try
            {
                pedidoActual.DatosAdicionales = additionalData.Text;
                multiView.ActiveViewIndex = 6;
                if (Convert.ToBoolean(Session["Enviado"]))
                {
                    Session.Remove("pedidoActual");
                    Session.Remove("Enviado");
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    new SendEmailLogic().EnviarEmail(pedidoActual.Email, GetMensajeAEnviar());
                    new FormularioLogic().CreatePedido(pedidoActual);
                    Session["Enviado"] = true;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error_view.aspx");
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message + "');", true);
            }
        }

        private string GetMensajeAEnviar()
        {
            string mensaje = "";
            try
            {
                if (VerificacionExcepcional())
                {
                    mensaje = "Nombre y Apellido: " + pedidoActual.NombreCliente + "\n" +
                             "Localidad: " + pedidoActual.Localidad + "\n" +
                             "Telefono: " + pedidoActual.Telefono + "\n" +
                             "email: " + pedidoActual.Email + "\n" +
                             "Tipo y disposicion: " + pedidoActual.TipoDisposicion.Descripcion + "\n" +
                             "Tipo de llanta: " + pedidoActual.TipoLlanta.Descripcion + "\n" +
                             "Capacidad de carga: " + pedidoActual.CapacidadDeCarga + "kg" + "\n" +
                             "Trocha del eje: " + pedidoActual.TrochaDelEje + "m" + "\n" +
                             "Datos adicionales: " + pedidoActual.DatosAdicionales;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(' Por favor inicie nuevamente el formulario.');", true);
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception)
            {
                Response.Redirect(Request.RawUrl);
            }
            return mensaje;
        }

        private bool VerificacionExcepcional()
        {
            if (string.IsNullOrEmpty(pedidoActual.NombreCliente) || string.IsNullOrEmpty(pedidoActual.Localidad) || string.IsNullOrEmpty(pedidoActual.Email)
                || string.IsNullOrEmpty(pedidoActual.Telefono) || pedidoActual.TipoDisposicion == null || pedidoActual.TipoLlanta == null  
                || string.IsNullOrEmpty(pedidoActual.CapacidadDeCarga.ToString()) || string.IsNullOrEmpty(pedidoActual.TrochaDelEje.ToString()) 
                || string.IsNullOrEmpty(pedidoActual.DatosAdicionales))
            {
                return false;
            } 
            else 
            {
                return true;
            }
        }

        protected void previusButtonPage6_Click(object sender, EventArgs e)
        {
            lblErrorTrocha.InnerHtml = "";
            txtTrochaDelEje.Text = Convert.ToDecimal(pedidoActual.TrochaDelEje).ToString();
            multiView.ActiveViewIndex = 4;
        }
        #endregion


        public bool IsNumeric(string x)
        {
            if (Regex.IsMatch(x, @"^[0-9]+$"))
            {
                return true;
            }
            return false;
        }

        private static bool IsEmail(string sEmailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            Session.Remove("pedidoActual");
            Response.Redirect(Request.RawUrl);
        }
    }
}