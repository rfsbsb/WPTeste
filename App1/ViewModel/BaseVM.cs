using App1.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace App1.ViewModel {
    public class BaseVM {

      public List<Livro> listaLivros;

      public async Task GetListaLivros() {
        var client = new HttpClient();
        var uri = new Uri("http://services.toulendo.com.br/s/bn");
        var response = await client.GetStringAsync(uri);
        JArray resultArray = JArray.Parse(response);
        this.listaLivros = resultArray.ToObject<List<Livro>>();
      }

    }
}
