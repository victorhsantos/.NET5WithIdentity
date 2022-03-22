using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace UsuariosApi.Models
{
    public class Menssagem
    {
        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        public Menssagem(IEnumerable<string> destinatario, string assunto, int usuarioID, string code)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress(d)));
            Assunto = assunto;
            Conteudo = $"http://localhost:6000/ativa?UserId={usuarioID}&Code={code}";
        }
    }
}
