using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosOOP.ConsoleApp
{
    class Chamado
    {    
        private string nome = null;
        private string descricao = null;
        private string equipamento = null;
        private DateTime data = DateTime.MinValue;
        
        public Chamado(DateTime data, string nome, string descricao, string equipamento)
        {
            this.data = data;
            this.nome = nome;
            this.descricao = descricao;
            this.equipamento = equipamento;
        }

        public string Nome
        {
            get
            {
                return nome;
            }
        }
        public DateTime Data
        {
            get
            {
                return data;
            }
        }
        public string Equipamento
        {
            get
            {
                return equipamento;
            }
        }
        public string Descricao
        {
            get
            {
                return nome;
            }
        }
   
        public void Editar(DateTime data, string nome, string descricao, string equipamento)
        {
            this.data = data;
            this.nome = nome;
            this.descricao = descricao;
            this.equipamento = equipamento;
        }

        public void Excluir()
        {       
            data = DateTime.MinValue;
            nome = null;
            descricao = null;
            equipamento = null;
        }
    }
}
