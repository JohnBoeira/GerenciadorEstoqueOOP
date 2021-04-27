using GestaoDeEquipamentosOOP.ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//VALIDAÇÃO DE 6 CARACTERES [OK]
//VALIDAÇÃO ENTRADAS DE DADOS DO USUÁRIO [OK]
//VALIDAÇÃO RELAÇAO EQUIPAMENTO PARA CHAMADO [OK?]
//VALIDAÇÃO DATA CHAMADO DEVE PEGAR DO SO [OK]
//VALIDAÇÃO NÃO PODE EXCLUIR EQUIPAMENTO COM CHAMADO ABERTO [OK]
//VALIDAÇÃO DATA DE FABRICAÇÃO NÃO DEVE SER NO FUTURO [OK]

namespace GestãoDeEquipamentos.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {          
            int opcao;
            //lista equipamentos
            List<Equipamento> Equipamentos = new List<Equipamento>();
            List<Chamado> Chamados = new List<Chamado>();

            Inicio:
            Console.Clear();
            Console.WriteLine("Digite a opção: \n 1 Para equipamentos, \n 2 para chamados, \n 3 para sair");
            opcao = Convert.ToInt32(Console.ReadLine());
            //equipamentos
            if (opcao == 1)
            {
                Console.Clear();
                while (true)
                {
                    int opcao2 = PedirOpcao();
                    //criar
                    if (opcao2 == 1)
                    {
                        int serie;
                        string nome, fabricante;
                        double preco;
                        DateTime data;
                        PedindoValoresEquipamento(out serie, out nome, out fabricante, out preco, out data);
                        //populando lista
                        Equipamentos.Add(new Equipamento(data, nome, fabricante, preco, serie));
                    }
                    //editar
                    else if (opcao2 == 2)
                    {
                        bool valorEncontrado = false;

                        Console.WriteLine("Digite a série do produto para edição: ");
                        int serieBusca = Convert.ToInt32(Console.ReadLine());

                        foreach (var equipamento in Equipamentos)
                        {
                            if (equipamento.Serie == serieBusca)
                            {
                                int serie;
                                string nome, fabricante;
                                double preco;
                                DateTime data;

                                PedindoValoresEquipamento(out serie, out nome, out fabricante, out preco, out data);

                                valorEncontrado = true; //VALIDA VALOR COMO ENCONTRADO                             
                                equipamento.Editar(data, nome, fabricante, preco, serie); //EDITA equip
                            }
                        }
                        ValorIncorreto(valorEncontrado);
                    }
                    //excluir
                    else if (opcao2 == 3)
                    {
                        bool valorIncorreto = false;
                        Console.WriteLine("Digite a série do equipamento para exclusão (que não esteja em uso): ");
                        int serieBusca = Convert.ToInt32(Console.ReadLine());

                        foreach (var equipamento in Equipamentos)
                        {
                            if (equipamento.Serie == serieBusca && equipamento.Emuso == false)
                            {                               
                                equipamento.Excluir();
                                valorIncorreto = true;        //VALIDA VALOR COMO INCORRETO
                            }
                        }
                        ValorIncorreto(valorIncorreto);
                    }
                    //listar
                    else if (opcao2 == 4)
                    {
                        ListandoEquipamentos(Equipamentos);
                    }
                    //voltar
                    else if (opcao2 == 5)
                    {
                        goto Inicio;
                    }
                    //VALIDA VALOR INVÁLIDO
                    else
                    {
                        Console.WriteLine("Valor inválido");
                        Console.ReadLine();
                    }
                }
            }
            //chamados
            else if (opcao == 2)
            {
                Console.Clear();
                while (true)
                {
                    int opcao2 = PedirOpcao();
                    //criar 
                    if (opcao2 == 1)
                    {
                        string nome, descricao, equipamento;                    

                        ListandoEquipamentos(Equipamentos); //LISTA EQUIPAMENTOS                      
                        PedindoValoresChamado(out nome, out descricao, out equipamento);
                        foreach (var item in Equipamentos)
                        {
                            if (item.Serie.ToString() == equipamento)
                            {
                                Chamados.Add(new Chamado(DateTime.Now, nome, descricao, item.Nome, item.Serie));
                                item.Emuso = true;
                            }
                            else //VALIDA SE DIGITAR SERIE NÃO EXISTENTE
                            {
                                Console.WriteLine("Favor digite série existente");
                            }
                        }
                    }
                    //editar
                    else if (opcao2 == 2)
                    {

                        Console.WriteLine("Digite a titulo para EXCLUIR: ");
                        string titulo = Console.ReadLine();
                        bool valorEncontrado = false;

                        foreach (var chamado in Chamados)
                        {
                            if (chamado.Nome == titulo)
                            {
                                string nome, descricao, equipamento;
                                
                                ListandoEquipamentos(Equipamentos); //LISTA EQUIPAMENTOS
                                PedindoValoresChamado(out nome, out descricao, out equipamento);

                                foreach (var item in Equipamentos)
                                {
                                    if (item.Serie.ToString() == equipamento)
                                    {
                                        chamado.Editar(nome, descricao, item.Nome,item.Serie);
                                    }
                                    else //VALIDA SE DIGITAR SERIE NÃO EXISTENTE
                                    {
                                        Console.WriteLine("Favor digite série existente");
                                    }
                                }
                                valorEncontrado = true;
                            }
                        }

                        ValorIncorreto(valorEncontrado);
                    }
                    //excluir
                    else if (opcao2 == 3)
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
                                valorEncontrado = true;
                            }
                        }
                        ValorIncorreto(valorEncontrado);
                    }
                    //listar
                    else if (opcao2 == 4)
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
                    //voltar
                    else if (opcao2 == 5)
                    {
                        goto Inicio;
                    }
                    //VALIDA VALOR INVÁLIDO
                    else
                    {
                        Console.WriteLine("Valor inválido");
                        Console.ReadLine();
                    }
                }
            }
            //fecha app
            else if (opcao == 3)
            {
                Environment.Exit(0);
            }
            //VALOR INCORRETO
            else
            {
                Console.WriteLine("Valor inválido");
                Console.ReadLine();
            }
        }

        private static void ListandoEquipamentos(List<Equipamento> Equipamentos)
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

        private static void ValorIncorreto(bool valorEncontrado)
        {
            if (valorEncontrado != true)
            {
                Console.WriteLine("Valor Incorreto!");
                Console.ReadLine();
            }
        }

        private static void PedindoValoresChamado(out string nome, out string descricao, out string equipamento)
        {
            bool valoresValidos;

            do
            {
                valoresValidos = false;
                Console.WriteLine("Digite título: ");
                nome = Console.ReadLine();
                if (nome == "")
                {
                    valoresValidos = true;
                    Console.WriteLine("Título inválido");
                    Console.ReadLine();
                }
                Console.WriteLine("Digite descricao do equipamento: ");
                descricao = Console.ReadLine();
                if (descricao == "")
                {
                    valoresValidos = true;
                    Console.WriteLine("descrição inválido");
                    Console.ReadLine();
                }
                Console.WriteLine("Digite Série do equipamento: ");
                equipamento = Console.ReadLine();

                
            } while (valoresValidos);


        }

        private static void PedindoValoresEquipamento(out int serie, out string nome, out string fabricante, out double preco, out DateTime data)
        {
            bool valoresValidos;

            do
            {
                Console.Clear();
                valoresValidos = false;
                Console.WriteLine("Digite nome do equipamento: ");
                nome = Console.ReadLine();

                if (nome.Length < 6)
                {
                    valoresValidos = true;
                    Console.WriteLine("nome inválido");
                    Console.ReadLine();                    
                }
                Console.WriteLine("Digite número série: ");
                if (!int.TryParse(Console.ReadLine(), out serie))
                {
                    valoresValidos = true;
                    Console.WriteLine("Valor inválido");
                    Console.ReadLine();
                }
                Console.WriteLine("Digite fabricante do produto: ");
                fabricante = Console.ReadLine();
                if (fabricante == "")
                {
                    valoresValidos = true;
                    Console.WriteLine("Valor inválido");
                    Console.ReadLine();
                }
                Console.WriteLine("Digite preco: ");
                if (!double.TryParse(Console.ReadLine(), out preco))
                {
                    valoresValidos = true;
                    Console.WriteLine("Valor inválido");
                    Console.ReadLine();
                }
                Console.WriteLine("Digite data: nesse formato(YYYY,MM,DD)");
                if (!DateTime.TryParse(Console.ReadLine(), out data) || data > DateTime.Now)
                {                    
                    valoresValidos = true;
                    Console.WriteLine("Valor inválido");
                    Console.ReadLine();
                }
            } while (valoresValidos);
        }

        private static int PedirOpcao()
        {
            Console.Clear();
            int opcao2;
            Console.WriteLine("Digite a opção: \n 1 Para criar \n 2 para editar \n 3 para excluir \n 4 para listar \n 5 para voltar");
            opcao2 = Convert.ToInt32(Console.ReadLine());
            return opcao2;
        }

    }
}