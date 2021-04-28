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
        private int serieEquipamento = 0;
        private DateTime data = DateTime.MinValue;

        public string Nome
        {
            get
            {
                return nome;
            }
        }
        public int SerieEquipamento
        {
            get
            {
                return serieEquipamento;
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
        public Chamado(DateTime data, string nome, string descricao, string equipamento, int serie)
        {
            this.serieEquipamento = serie;
            this.data = data;
            this.nome = nome;
            this.descricao = descricao;
            this.equipamento = equipamento;
        }
        public void Editar(string nome, string descricao, string equipamento, int serie)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.equipamento = equipamento;
            this.serieEquipamento = serie;
        }
        public void Excluir()
        {
            serieEquipamento = 0;
            data = DateTime.MinValue;
            nome = null;
            descricao = null;
            equipamento = null;
        }
    }
}
