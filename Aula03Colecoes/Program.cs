using System;
using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;

namespace Aula03Colecoes
{
    public class Program
    {
        static List<Funcionario> List = new List<Funcionario>();

        static void Main(string[] args)
        {
            CriarLista();
            ObterEstatisticas();
        }

        public static void ObterEstatisticas()
        {
            int qtdFunc = List.Count();

            decimal somaSal = List.Sum(x => x.Salario);
             
            Console.WriteLine($"Existem {qtdFunc} funcionarios, cujo a soma de seus salarios resulta em: {somaSal}");
        }

        public static void ObterFuncionariosRecentes()
        {
            List.RemoveAll(x => x.Id <= 4);

            List = List.OrderBy(x => x.Salario).ToList();
            ExibirLista();
        }

        public static void ObterPorNome()
        {
            Console.WriteLine("Digite o nome do funcionario: ");
            string nome = Console.ReadLine();
            Funcionario fbusca = List.Find(x => x.Nome == nome);

            if (fbusca == null)
                Console.WriteLine("Não encontrado");
            else
                Console.WriteLine($"Funcionario encontrado! seu Id é: {fbusca.Id}");
        }

        public static void ObterPorSalario()
        {
            Console.WriteLine("Digite o valor minimo");
            decimal salario = decimal.Parse(Console.ReadLine());
            List = List.FindAll(x => x.Salario >= salario);
            ExibirLista();
        }

        public static void ObterPorIdDigitado()
        {
            Console.WriteLine("Digite o Id");
            int id = int.Parse(Console.ReadLine());
            Funcionario fbusca = List.Find(x => x.Id == id);

            if (fbusca == null)
                Console.WriteLine("Não encontrado");
            else
                Console.WriteLine($"Funcionario encontrado: {fbusca.Nome}");
        }

        public static void AdicionarFuncionario()
        {
            Funcionario f = new Funcionario();

            Console.WriteLine("Digite seu Id: ");
            f.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite seu nome: ");
            f.Nome = Console.ReadLine();
            Console.WriteLine("Digite seu salario: ");
            f.Salario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Digite a data de admissão: ");
            f.DataAdmissao = DateTime.Parse(Console.ReadLine());
            
            if (string.IsNullOrEmpty(f.Nome)) {
                Console.WriteLine("O nome deve ser preenchido");
                return;
            } else if (f.Salario == 0) {
                Console.WriteLine("Valor do sálario não pode ser 0");
                return;
            } else {
                List.Add(f);
                ExibirLista();
            }
        }

        public static void ObterPorID()
        {
            List = List.FindAll(x => x.Id == 1);
            ExibirLista();
        }

        public static void ExibirLista()
        {
            string dados = "";
            for (int i = 0; i < List.Count; i++) {
                dados += string.Format("\nId: {0} \n", List[i].Id);
                dados += string.Format("Nome: {0} \n", List[i].Nome);
                dados += string.Format("CPF: {0} \n", List[i].Cpf);
                dados += string.Format("Adimissao: {0:dd/MM/yyyy} \n", List[i].DataAdmissao);
                dados += string.Format("Salario: {0:c2} \n", List[i].Salario);
                dados += string.Format("Tipo: {0} \n", List[i].TipoFuncionario);
            }
            Console.WriteLine(dados);
        }

         public static void CriarLista()
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Rudo";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            List.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Maka";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            List.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Crona";
            f3.Cpf = "135792468";
            f3.DataAdmissao = DateTime.Parse("01/11/2003");
            f3.Salario = 70.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            List.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Soul Eater";
            f4.Cpf = "246813579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            List.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Mob";
            f5.Cpf = "246813579";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            List.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Yoruichi";
            f6.Cpf = "246813579";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            List.Add(f6);
        }
    }
}