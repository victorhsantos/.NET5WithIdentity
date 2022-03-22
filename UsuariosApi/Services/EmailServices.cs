using MailKit.Net.Smtp;
using MimeKit;
using System;
using UsuariosApi.Interfaces.Services;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class EmailServices : IEmailServices
    {
        public void SendEmail(string[] destinatario, string assunto, int usuarioID, string code)
        {
            var menssagem = new Menssagem(destinatario,assunto,usuarioID,code);
            var msgEmail = CriaCorpoEmail(menssagem);
            Send(msgEmail);
        }

        private void Send(MimeMessage msgEmail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("Conexao a fazer");
                    //TODO Auth de Email
                    client.Send(msgEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CriaCorpoEmail(Menssagem menssagem)
        {
            var msgEmail = new MimeMessage();
            msgEmail.From.Add(new MailboxAddress("ADD REMETENTE"));
            msgEmail.To.AddRange(menssagem.Destinatario);
            msgEmail.Subject = menssagem.Assunto;
            msgEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = menssagem.Conteudo
            };

            return msgEmail;
        }
    }
}
