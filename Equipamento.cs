using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosOOP.ConsoleApp
{
    class Equipamento
    {
        private bool emuso = false;
        private int serie = 0;
        private string nome = null;
        private string fabricante = null;
        private double preco = 0;
        private DateTime data = DateTime.MinValue;

        public bool Emuso
        {
            set { emuso = value; }
            get
            {
                return emuso;
            }
        }
        public int Serie
        {
            get
            {
                return serie;
            }
            
        }
        public string Nome
        {
            get
            {
                return nome;
            }
            
        }
        public string Fabricante
        {
            get
            {
                return fabricante;
            }
        }
        public double Preco
        {
            get
            {
                return preco;
            }
        }
        public DateTime Data
        {
            get
            {
                return data;
            }
        }    
        public Equipamento(DateTime data, string nome, string fabricante, double preco, int serie)
        {
            this.data = data;
            this.nome = nome;
            this.fabricante = fabricante;
            this.preco = preco;
            this.serie = serie;        
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
