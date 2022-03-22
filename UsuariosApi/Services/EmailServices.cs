using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using UsuariosApi.Interfaces.Services;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class EmailServices : IEmailServices
    {

        private readonly IConfiguration _configuration;

        public EmailServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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
                    client.Connect(
                        _configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"),
                        true);
                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    client.Authenticate(
                        _configuration.GetValue<string>("EmailSettings:From"), 
                        _configuration.GetValue<string>("EmailSettings:Password"));                    
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
            msgEmail.From.Add(new MailboxAddress(
                _configuration.GetValue<string>("EmailSettings:From")));
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
