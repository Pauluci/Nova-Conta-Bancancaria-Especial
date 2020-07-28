using System;

namespace Novo_Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int sair = 0;
                ContaBancaria conta = new ContaBancaria();
     
                while (sair == 0)
                {
                    ImprimeOpcoes();
                    int opcao = int.Parse(Console.ReadLine());
                    if (opcao == 0)
                    {
                        sair = 1;    
                    }
                    else
                    {
                        if (opcao == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("======Abertura de nova conta=======");
                            Console.WriteLine("Digite o nome do novo correntista: ");
                            string nome = Console.ReadLine();
                            Console.WriteLine("Digite o valor do primeiro depósito: ");
                            int valor = int.Parse(Console.ReadLine());
                            conta = new ContaBancaria(nome, valor);
                            Console.WriteLine($" Numero da nova conta  é {conta.Conta} do {conta.Nome} saldo é de {conta.Saldo}");
                        }
                        if (opcao == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("======Abertura de nova conta Especaial=======");
                            Console.WriteLine("Digite o nome do novo correntista: ");
                            string nome = Console.ReadLine();
                            Console.WriteLine("Digite o valor do primeiro depósito: ");
                            int valor = int.Parse(Console.ReadLine());
                            Console.WriteLine("Digite o valor do limite: ");
                            int limite = int.Parse(Console.ReadLine());
                            conta = new ContaEspecial(nome, valor, limite);
                            Console.WriteLine($" Numero da nova conta  é {conta.Conta} do {conta.Nome} saldo é de {conta.Saldo}");
                        }
                        else if (opcao == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("======Novo depósito=======");
                            Console.WriteLine("Digite o valor a ser depositado: ");
                            int valor = int.Parse(Console.ReadLine());
                            conta.Deposito(valor, DateTime.Now, "Deposito");
                            Console.WriteLine("Deposito realizado com sucesso! ");
                        }
                        else if (opcao == 4)
                        {
                            Console.Clear();
                            Console.WriteLine("======Novo Saque=======");
                            Console.WriteLine("Digite o valor a ser Sacado: ");
                            int valor = int.Parse(Console.ReadLine());
                            conta.Saque(valor, DateTime.Now, "Saque");
                            Console.WriteLine("Saque o realizado com sucesso! ");
                        }
                        else if (opcao == 5)
                        {
                            Console.Clear();
                            Console.WriteLine(conta.Extrato());
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException e){
                Console.WriteLine(e.ToString());
            }
        }

        static public void ImprimeOpcoes()
        {
            Console.WriteLine("============Opções==============");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Criar uma nova conta:");
            Console.WriteLine("2 - Criar uma nova conta Especial:");
            Console.WriteLine("3 - Fezer um Depsito");
            Console.WriteLine("4 - Fazer um Saque:");
            Console.WriteLine("5 - Tirar um Extrato");
            Console.WriteLine("================================");
            Console.WriteLine("Escolha uma das opções: ");

        }
    }
}
