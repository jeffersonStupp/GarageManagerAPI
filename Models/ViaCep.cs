using Newtonsoft.Json;

namespace GarageManager.Models
{
    public class ViaCep
    {
        public string Cep { get; set; }

        [JsonProperty("logradouro")]
        public string EnderecoLogradouro { get; set; } // "logradouro": "",

        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string Ddd { get; set; }
        public string Siafi { get; set; }
    }
}