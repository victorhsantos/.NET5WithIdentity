using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FilmesApi.Models
{
    public class Cinema
    {
        
        public int Id { get; set; }        
        public string Nome { get; set; }
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public virtual Gerente Gerente { get; set; }
        public int GerenteId { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}