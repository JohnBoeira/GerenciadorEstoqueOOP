using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosOOP.ConsoleApp
{
    class Chamado
    {    
        public string nome = null;
        public string descricao = null;
        public string equipamento = null;
        public DateTime data = DateTime.MinValue;

        public Chamado(DateTime data, string nome, string descricao, string equipamento)
        {
            this.data = data;
            this.nome = nome;
            this.descricao = descricao;
            this.equipamento = equipamento;
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
