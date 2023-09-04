using contaBancaria.Model;

namespace contaBancaria
{
    internal class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;
        static void Main(string[] args)
        {
            int opcao;

            ContaCorrente cc1 = new ContaCorrente(354, 20, 1, "Samantha", 100000000.00M, 1000.00M);

            cc1.Visualizar();
            cc1.Sacar(200000000.00M);
            cc1.Visualizar();
            cc1.Depositar(5000);
            cc1.Visualizar();

            ContaPoupanca cp1 = new ContaPoupanca(678, 30, 2, "Theo", 1000, 100, 06);

            cp1.Visualizar();
            cp1.Sacar(1200);
            cp1.Visualizar();
            cp1.Depositar(50);
            cp1.Visualizar();
            

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("*********************************************************");
                Console.WriteLine("                                                         ");
                Console.WriteLine("                  BANCO TRANSIÇÃO                        ");
                Console.WriteLine("                                                         ");
                Console.WriteLine("*********************************************************");
                Console.WriteLine("           1 - Criar Conta                               ");
                Console.WriteLine("           2 - Listar todas as Contas                    ");
                Console.WriteLine("           3 - Buscar Conta por Número                   ");
                Console.WriteLine("           4 - Atualizar Dados da Conta                  ");
                Console.WriteLine("           5 - Apagar Conta                              ");
                Console.WriteLine("           6 - Sacar                                     ");
                Console.WriteLine("           7 - Depositar                                 ");
                Console.WriteLine("           8 - Transferir Valores entre Contas           ");
                Console.WriteLine("           9 - Sair                                      ");
                Console.WriteLine("                                                         ");
                Console.WriteLine("*********************************************************");
                Console.WriteLine("Entre com a opção desejada:                              ");
                Console.WriteLine("                                                         ");
                Console.ResetColor();

                opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 9)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("*********************************************************");
                    Console.WriteLine("                                                         ");
                    Console.WriteLine("    Banco Transição: Onde o novo é a todo instante!      ");
                    Console.WriteLine("                                                         ");
                    Console.WriteLine("                                                         ");


                    Sobre();
                    Console.ResetColor();
                    System.Environment.Exit(0);

                }

                switch (opcao)
                {
                    case 1:
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Criar contra\n\n");
                        Console.ResetColor();

                        KeyPress();
                        break;

                    case 2:
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Listar todas as Contas\n\n");
                        Console.ResetColor();

                        KeyPress();
                        break;

                    case 3:
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Buscar Conta por Número\n\n");
                        Console.ResetColor();

                        KeyPress();
                        break;

                    case 4:
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Atualizar Dados da Conta\n\n");
                        Console.ResetColor();
                        break;

                    case 5:
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Apagar Conta\n\n");
                        Console.ResetColor();

                        KeyPress();
                        break;

                    case 6:
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Saque\n\n");
                        Console.ResetColor();
                        break;

                    case 7:
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Depósito\n\n");
                        Console.ResetColor();

                        KeyPress();
                        break;

                    case 8:
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Tranferência entre Contas\n\n");
                        Console.ResetColor();

                        KeyPress();
                        break;

                    default:

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpção Inválida!");
                        Console.ResetColor();

                        KeyPress();
                        break;
                }
            }
        }
        static void Sobre()
        {
            Console.WriteLine("*********************************************************");
            Console.WriteLine("                                                         ");
            Console.WriteLine("       Projeto Desenvolvido por: Samantha Blazizza       ");
            Console.WriteLine("           E-mail: samantha.blazizza@gmail.com           ");
            Console.WriteLine("               github.com/samanthablazizza               ");
            Console.WriteLine("                                                         ");
            Console.WriteLine("*********************************************************");
            Console.ResetColor();
        }
        static void KeyPress()
        {
            do
            {
                Console.Write("\nPressione Enter para Continuar...");
                consoleKeyInfo = Console.ReadKey();
            }
            while (consoleKeyInfo.Key != ConsoleKey.Enter);



        }
    }
}
        