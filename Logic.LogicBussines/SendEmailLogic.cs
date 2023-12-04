using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace Logic.LogicBussines
{
    public class SendEmailLogic
    {
        public void EnviarEmail(string correoDeDestino, string mensajeAEnviar)
        {
            string correoEmisor = ConfigurationManager.AppSettings["CorreoUsuario"].ToString();
            string contraseña = ConfigurationManager.AppSettings["CorreoContraseña"].ToString();
            string displayName = "Solicitud de pedido =)";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(correoEmisor, displayName);
                mail.To.Add(correoDeDestino);

                mail.Subject = "Solicitud de pedido"; //--> Asunto
                mail.Body = mensajeAEnviar;
                mail.IsBodyHtml = false;

                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(correoEmisor, contraseña);

                client.Send(mail);
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al enviar email con el pedido. Por favor informe a la empresa, lo solucionaremos a la brevedad", ex);
                throw ExcepcionManejada;
            }
        }
    }
}
