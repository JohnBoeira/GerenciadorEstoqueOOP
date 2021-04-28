using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//VALIDAÇÃO RELAÇAO EQUIPAMENTO PARA CHAMADO [OK?]
//VALIDAÇÃO DATA CHAMADO DEVE PEGAR DO SO [OK]
//VALIDAÇÃO NÃO PODE EXCLUIR EQUIPAMENTO COM CHAMADO ABERTO [OK]
//VALIDAÇÂO DE VALOR NÃO ENCONTRADO PARA EDITARs EXCLUIRs [OK]

namespace GestaoDeEquipamentosOOP.ConsoleApp
{
    class Controle
    {
        private List<Equipamento> Equipamentos = new List<Equipamento>();
        private List<Chamado> Chamados = new List<Chamado>();
        //MÉTODOS DE EQUIPAMENTO
        public void CriarEquipamento()
        {
            string serie, nome, fabricante, preco, data;

            do
            {
                PedindoValoresEquipamento(out serie, out nome, out fabricante, out preco, out data);
            } while (Valida.ValidaEntradasEquip(data, nome, fabricante, preco, serie));

            Equipamentos.Add(new Equipamento(Convert.ToDateTime(data), nome, fabricante, Convert.ToDouble(preco), Convert.ToInt32(serie)));
        }
        public void EditarEquipamento()
        {
            bool valorEncontrado = false;

            Console.WriteLine("Digite a série do produto para edição: ");
            string serieAux = Console.ReadLine(); //string para verificar 
            int serieBusca; 
            if (Valida.ValidaValorInt(serieAux))//VALIDA VALOR NUMERICO
            {
                serieBusca = Convert.ToInt32(serieAux);
                foreach (var equipamento in Equipamentos)
                {
                    if (equipamento.Serie == serieBusca)
                    {
                        string serie, nome, fabricante, preco, data;

                        do
                        {
                            PedindoValoresEquipamento(out serie, out nome, out fabricante, out preco, out data);
                        } while (Valida.ValidaEntradasEquip(data, nome, fabricante, preco, serie)); //SE ALGO ESTIVER INVALIDO RETORNA TRUE

                        valorEncontrado = true; //VALIDA VALOR COMO ENCONTRADO                             
                        equipamento.Editar(Convert.ToDateTime(data), nome, fabricante, Convert.ToDouble(preco), Convert.ToInt32(serie)); //EDITA equip
                       
                    }
                }
                ValorNaoEncontrado(valorEncontrado);
            }
            else //CASO não numerico
            {
                Console.WriteLine("Apenas valor númerico inteiro aceito!");
                Console.ReadLine();
            }

        }
        public void ExcluirEquipamento()
        {
            bool valorEncontrado = false;

            Console.WriteLine("Digite a série do equipamento para exclusão (que não esteja em uso): ");
            string serieAux = Console.ReadLine();
            int serieBusca;
            if (Valida.ValidaValorInt(serieAux))//VALIDA VALOR NUMERICO
            {
                serieBusca = Convert.ToInt32(serieAux);
                foreach (var equipamento in Equipamentos)
                {
                    if (equipamento.Serie == serieBusca)
                    {
                        valorEncontrado = true;
                        if (equipamento.Emuso != false)
                        {
                            Console.WriteLine("Equipamento está em uso em um chamado!");
                            Console.ReadLine();
                        }
                        else
                        {
                            equipamento.Excluir();
                            MensagemDeSucesso();
                        }

                        //VALIDA VALOR COMO INCORRETO
                    }
                }
                ValorNaoEncontrado(valorEncontrado);
            }
            else
            {
                Console.WriteLine("Apenas valor númerico inteiro aceito!");
                Console.ReadLine();
            }

        }
        public void ListarEquipamentos()
        {
            foreach (var equipamento in Equipamentos)
            {
                if (equipamento.Nome != null) //VALIDA PARA NÃO APARECER OBJETO EXCLUIDO
                {
                    Console.WriteLine($"Série:{equipamento.Serie} nome: {equipamento.Nome} fabricante: {equipamento.Fabricante} preco: {equipamento.Preco} data: {equipamento.Data.ToShortDateString()}");
                }
            }
            Console.ReadLine();
        }
        //MÉTODOS DE CHAMADO
        public void CriarChamado()
        {
            string nome, descricao, equipamento;
            bool valorEncontrado = false;
            ListarEquipamentos(); //LISTA EQUIPAMENTOS                      
            PedindoValoresChamado(out nome, out descricao, out equipamento);
            foreach (var item in Equipamentos)
            {
                if (item.Serie.ToString() == equipamento)
                {
                    if (Valida.ValidaEntradasChamado(nome, descricao))
                    {
                        Chamados.Add(new Chamado(DateTime.Now, nome, descricao, item.Nome, item.Serie));
                        item.Emuso = true;
                        valorEncontrado = true;
                    }
                }
            }
            ValorNaoEncontrado(valorEncontrado);
        }
        public void EditarChamado()
        {
            Console.WriteLine("Digite a titulo para EDITAR: ");
            string titulo = Console.ReadLine();
            bool valorEncontrado = false;

            foreach (var chamado in Chamados)
            {
                if (chamado.Nome == titulo)
                {
                    string nome, descricao, equipamento;

                    ListarEquipamentos(); //LISTA EQUIPAMENTOS
                    PedindoValoresChamado(out nome, out descricao, out equipamento);

                    foreach (var item in Equipamentos)
                    {
                        if (item.Serie.ToString() == equipamento && Valida.ValidaEntradasChamado(nome, descricao))
                        {
                            chamado.Editar(nome, descricao, item.Nome, item.Serie);
                            
                        }
                        else //VALIDA SE DIGITAR SERIE NÃO EXISTENTE
                        {
                            Console.WriteLine("Favor digite série existente");
                        }
                    }
                    valorEncontrado = true;
                }
            }

            ValorNaoEncontrado(valorEncontrado);
        }
        public void ExcluirChamado()
        {
            Console.WriteLine("Digite a titulo para EXCLUIR: ");
            string titulo = Console.ReadLine();
            bool valorEncontrado = false;
            foreach (var chamado in Chamados)
            {
                if (chamado.Nome == titulo)
                {
                    foreach (var item in Equipamentos)
                    {
                        if (item.Serie == chamado.SerieEquipamento)
                        {
                            item.Emuso = false;
                        }
                    }
                    chamado.Excluir();
                    MensagemDeSucesso();
                    valorEncontrado = true;
                }
            }
            ValorNaoEncontrado(valorEncontrado);
        }
        private void MensagemDeSucesso()
        {
            Console.WriteLine("OPERAÇÃO REALIZADA COM SUCESSO!");
            Console.ReadLine();
        }
        public void ListarChamado()
        {
            foreach (var chamado in Chamados)
            {
                if (chamado.Nome != null) //VALIDA PARA NÃO APARECER OBJETO EXCLUIDO
                {
                    string diasDif = (DateTime.Now - chamado.Data).ToString("dd");
                    Console.WriteLine($"Título:{chamado.Nome} equipamento: {chamado.Equipamento} data: {chamado.Data.ToShortDateString()} dias em aberto: {diasDif}");
                }
            }
            Console.ReadLine();
        }
        //
        private void PedindoValoresEquipamento(out string serie, out string nome, out string fabricante, out string preco, out string data)
        {
            Console.Clear();
            Console.WriteLine("Digite nome do equipamento: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite número série: ");
            serie = Console.ReadLine();

            Console.WriteLine("Digite fabricante do produto: ");
            fabricante = Console.ReadLine();

            Console.WriteLine("Digite preco: ");
            preco = Console.ReadLine();

            Console.WriteLine("Digite data: nesse formato(YYYY,MM,DD)");
            data = Console.ReadLine();

        }
        private void PedindoValoresChamado(out string nome, out string descricao, out string equipamento)
        {
            Console.WriteLine("Digite título: ");
            nome = Console.ReadLine();

            Console.WriteLine("Digite descricao do equipamento: ");
            descricao = Console.ReadLine();

            Console.WriteLine("Digite Série do equipamento: ");
            equipamento = Console.ReadLine();
        }
        private static void ValorNaoEncontrado(bool valorEncontrado)
        {
            if (valorEncontrado != true)
            {
                Console.WriteLine("Valor não encontrado!");
                Console.ReadLine();
            }
        }
    }
}
