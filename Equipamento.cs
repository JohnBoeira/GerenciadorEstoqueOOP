using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosOOP.ConsoleApp
{
    class Equipamento
    {
        public int serie = 0;
        public string nome = null;
        public string fabricante = null;
        public double preco = 0;
        public DateTime data = DateTime.MinValue;  
       
        public Equipamento(DateTime data, string nome, string fabricante, double preco, int serie)
        {
            this.data = data;
            this.nome = nome;
            this.fabricante = fabricante;
            this.preco = preco;
            this.serie = serie;
        }
        public Equipamento()
        {
            serie = 0;
            nome = null;
            fabricante = null;
            preco = 0;
            data = DateTime.MinValue;
        }
        public void Editar(DateTime data, string nome, string fabricante, double preco, int serie)
        {
            this.data = data;
            this.nome = nome;
            this.fabricante = fabricante;
            this.preco = preco;
            this.serie = serie;
        }

        public void Excluir()
        {          
            serie = 0;
            nome = null;
            fabricante = null;
            preco = 0;
            data = DateTime.MinValue;
        }

    }
}
