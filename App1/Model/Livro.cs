using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Model {
  public class Livro {
    public string Codigo { get; set; }
    public string Titulo { get; set; }
    public List<String> Capas { get; set; }
    public List<String> Autores { get; set; }
    public string Resenha { get; set; }
  }
}
