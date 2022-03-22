namespace UsuariosApi.Interfaces.Services
{
    public interface IEmailServices
    {
        public void SendEmail(string[] destinatario, string assunto, int usuarioID, string code);
    }
}
