using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CRMALL.Teste.Domain.Helper
{
    public static class CepHelper
    {
        public static T ConsultarCep<T>(string cep)
        {
            cep = cep.Replace("-", string.Empty);
            var client = new HttpClient();
            var url = $@"https://viacep.com.br/ws/{cep}/json/";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = client.SendAsync(request).Result?.Content?.ReadAsStringAsync()?.Result;

            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
