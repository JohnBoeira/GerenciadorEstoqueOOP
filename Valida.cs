using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentosOOP.ConsoleApp
{
    class Valida
    {
        //VALIDAÇÃO DE 6 CARACTERES [OK]
        //VALIDAÇÃO ENTRADAS DE DADOS DO USUÁRIO equip[ok]
        //VALIDAÇÃO ENTRADAS DE DADOS DO USUÁRIO chamado[ok]          
        //VALIDAÇÃO DATA DE FABRICAÇÃO NÃO DEVE SER NO FUTURO [OK]

        /// <summary>
        /// Método para verificar entrada de valores de equipamento
        /// </summary>
        /// <param name="data"></param>
        /// <param name="nome"></param>
        /// <param name="fabricante"></param>
        /// <param name="preco"></param>
        /// <param name="serie"></param>
        /// <returns>False para valido, true para não validado</returns>
        static public bool ValidaEntradasEquip(string data, string nome, string fabricante, string preco, string serie)
        {
            int serieAux;
            double precoAux;
            DateTime dataAux;
            if (nome.Length < 6)
            {
                Console.WriteLine("Operação falhou\nNome deve ter no mínimo 6 caracteres!");
                Console.ReadLine();
                return true;
            }
            else if (!int.TryParse(serie, out serieAux))
            {
                Console.WriteLine("Operação falhou\nValor inválido, apenas valores números para série ");
                Console.ReadLine();
                return true;
            }
            else if (!double.TryParse(preco, out precoAux))
            {
                Console.WriteLine("Operação falhou\nValor inválido, apenas valores números para preço");
                Console.ReadLine();
                return true;
            }
            else if (fabricante.Length < 1 || fabricante == " ")
            {
                Console.WriteLine("Operação falhou\nValor inválido, fabricante não pode ser vazio");
                Console.ReadLine();
                return true;
            }
            else if (!DateTime.TryParse(data, out dataAux))
            {
                Console.WriteLine("Operação falhou\nValor inválido, verifique se a data está no formato correto");
                Console.ReadLine();
                return true;
            }
            else if (dataAux > DateTime.Now)
            {
                Console.WriteLine("Operação falhou");
                Console.WriteLine("Valor inválido, data não pode ser futura");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("\nSalvo com sucesso!!!");
                Console.ReadLine();
                return false; //false = valido p/ do while            
            }
        }
        /// <summary>
        /// Método para verificar entrada de valores do chamado
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="descricao"></param>
        /// <returns>true para valido, false para não validado</returns>
        static public bool ValidaEntradasChamado(string nome, string descricao)
        {
            if (nome.Length < 1 || nome == " ")
            {
                Console.WriteLine("Operação falhou\nValor inválido, nome não pode ser vazio");
                Console.ReadLine();
                return false;
            }
            else if (descricao.Length < 1 || descricao == " ")
            {
                Console.WriteLine("Operação falhou\nValor inválido, descricao não pode ser vazio");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine("\nSalvo com sucesso!!!");
                Console.ReadLine();
                return true; //true = valido p/ ifs     
            }
        }

        static public bool ValidaValorInt(string valor)
        {
            int aux;
            return int.TryParse(valor, out aux); //false para incorreto

        }

    }
}
