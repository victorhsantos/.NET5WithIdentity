using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FilmesApi.Models
{
    public class Gerente
    {
       
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public virtual List<Cinema> Cinemas { get; set; }
    }
}
