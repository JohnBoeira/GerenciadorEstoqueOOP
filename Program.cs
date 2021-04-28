using GestaoDeEquipamentosOOP.ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GestãoDeEquipamentos.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            Controle operacoes = new Controle();
            Inicio:
            Console.Clear();
            Console.WriteLine("Digite a opção: \n 1 Para equipamentos \n 2 para chamados \n 3 para sair");
            opcao = Convert.ToInt32(Console.ReadLine());
            //equipamentos
            if (opcao == 1)
            {
                while (true)
                {
                    int opcao2 = PedirOpcao();

                    switch (opcao2)
                    {
                        case 1: operacoes.CriarEquipamento(); break;
                        case 2: operacoes.EditarEquipamento(); break;
                        case 3: operacoes.ExcluirEquipamento(); break;
                        case 4: operacoes.ListarEquipamentos(); break;
                        case 5: goto Inicio;
                        default: ValorInválido(); break;
                    }
                }
            }
            //chamados
            else if (opcao == 2)
            {
                while (true)
                {
                    int opcao2 = PedirOpcao();

                    switch (opcao2)
                    {
                        case 1: operacoes.CriarChamado(); break;
                        case 2: operacoes.EditarChamado(); break;
                        case 3: operacoes.ExcluirChamado(); break;
                        case 4: operacoes.ListarChamado(); break;
                        case 5: goto Inicio;
                        default: ValorInválido(); break;
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
        //MSG DE VALOR INVÁLIDO DE MENU SECUNDÁRIO
        private static void ValorInválido()
        {
            Console.WriteLine("Valor inválido");
            Console.ReadLine(); ;
        }
        //menu secundário
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