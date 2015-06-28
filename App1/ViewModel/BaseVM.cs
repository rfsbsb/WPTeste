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
      public List<Livro> listaLivrosResultado;
      public Livro livro;

      public async Task GetListaLivros() {
        var client = new HttpClient();
        var uri = new Uri("http://services.toulendo.com.br/s/bn");
        var response = await client.GetStringAsync(uri);
        JArray resultArray = JArray.Parse(response);
        this.listaLivros = resultArray.ToObject<List<Livro>>();
      }

      public async Task GetBuscaLivros(String nome) {
        var client = new HttpClient();
        var uri = new Uri(string.Format("http://services.toulendo.com.br/s/bn?title={0}", nome));
        var response = await client.GetStringAsync(uri);
        JArray resultArray = JArray.Parse(response);
        this.listaLivrosResultado = resultArray.ToObject<List<Livro>>();
      }

      public async Task GetLivro(string nid) {
        var client = new HttpClient();
        var uri = new Uri(string.Format("http://services.toulendo.com.br/s/todos?nid={0}", nid));
        var response = await client.GetStringAsync(uri);
        JArray resultArray = JArray.Parse(response);
        this.livro = resultArray[0].ToObject<Livro>();
      }

      public async Task GetListaLivrosAleatorios()
      {
          var client = new HttpClient();
          var uri = new Uri("http://services.toulendo.com.br/s/random?items={0}");
          var response = await client.GetStringAsync(uri);
          JArray resultArray = JArray.Parse(response);
          this.listaLivros = resultArray.ToObject<List<Livro>>();
      }
    }
}
