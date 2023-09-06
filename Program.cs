using contaBancaria.Controller;
using contaBancaria.Model;
using System.Runtime.CompilerServices;

namespace contaBancaria
{
    internal class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;
        static void Main(string[] args)
        {
            int opcao, agencia, tipo, aniversario, numero, numeroDestino;
            string? titular;
            decimal saldo, limite, valor;

            ContaController contas = new();

            ContaCorrente cc1 = new ContaCorrente(contas.GerarNumero(), 123, 1, "Samantha", 1000000.00M, 1000.00M);
            contas.Cadastrar(cc1);

            ContaPoupanca cp1 = new ContaPoupanca(contas.GerarNumero(), 123, 2, "Theo", 1000, 100, 06);
            contas.Cadastrar(cp1);

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
                Console.ResetColor();

                Console.Write("Entre com a opção desejada: ");
                Console.ResetColor();
                               
                //Tratamento de Exceção para impedir a digitação de stings
                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Digite um valor inteiro entre 1 e 9");
                    Console.ResetColor();
                    opcao = 0;
                }

                if (opcao == 9)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("\nBanco Transição: Onde o novo é a todo instante!          ");
                    Sobre();
                    Console.ResetColor();
                    System.Environment.Exit(0);
                }
                switch (opcao)
                {
                    case 1:
                        
                        Console.WriteLine("Criar contra\n\n");
                        
                        Console.Write("Digite o Número da Agência: ");
                        agencia = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Digite o Nome do Titular: ");
                        titular = Console.ReadLine();
                        titular??= string.Empty;

                        do 
                        {
                            Console.Write("Digite o Tipo da Conta: ");
                            tipo = Convert.ToInt32(Console.ReadLine());
                        } 
                        while (tipo != 1 && tipo != 2);

                        Console.Write("Digite o Saldo da Conta: ");
                        saldo = Convert.ToDecimal(Console.ReadLine());

                        switch (tipo)
                        {
                            case 1:
                                Console.Write("Digite o Limite da Conta: ");
                                limite = Convert.ToDecimal(Console.ReadLine());

                                contas.Cadastrar(new ContaCorrente(contas.GerarNumero(), agencia, tipo, titular, saldo, limite));
                                break;

                            case 2:
                                Console.Write("Digite o Aniversário da Conta: ");
                                aniversario = Convert.ToInt32(Console.ReadLine());

                                contas.Cadastrar(new ContaPoupanca(contas.GerarNumero(), agencia, tipo, titular, saldo, aniversario));
                                break;
                        }                       
                        KeyPress();
                        break;

                    case 2:                        
                        Console.WriteLine("Listar todas as Contas\n\n");

                        contas.ListarTodas();

                        KeyPress();
                        break;

                    case 3:                        
                        Console.Write("Buscar Conta por Número\n\n");                 

                        Console.Write("Digite o número da Conta: ");                        
                        numero = Convert.ToInt32(Console.ReadLine());

                        contas.ProcurarPorNumero(numero);

                        KeyPress();
                        break;

                    case 4:                        
                        Console.WriteLine("Atualizar Dados da Conta\n\n");                        

                        Console.Write("Digite o número da Conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        var conta = contas.BuscarNaCollecion(numero);

                        if (conta is not null)
                        {
                            Console.Write("Digite o Número da Agência: ");
                            agencia = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Digite o Nome do Titular: ");
                            titular = Console.ReadLine();
                            titular ??= string.Empty;

                            Console.Write("Digite o Saldo da Conta: ");
                            saldo = Convert.ToDecimal(Console.ReadLine());

                            tipo = conta.GetTipo();
                            switch (tipo)
                            {
                                case 1:
                                    Console.Write("Digite o Limite da Conta: ");
                                    limite = Convert.ToDecimal(Console.ReadLine());

                                    contas.Atualizar(new ContaCorrente(numero, agencia, tipo, titular, saldo, limite));
                                    break;

                                case 2:
                                    Console.Write("Digite o Aniversário da Conta: ");
                                    aniversario = Convert.ToInt32(Console.ReadLine());

                                    contas.Atualizar(new ContaPoupanca(numero, agencia, tipo, titular, saldo, aniversario));
                                    break;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"A conta {numero} não foi encontrada!");
                            Console.ResetColor();
                        }                                                
                        KeyPress();
                        break;

                    case 5:                        
                        Console.WriteLine("Apagar Conta\n\n");                        

                        Console.WriteLine("Digite o número da Conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        contas.Deletar(numero);

                        KeyPress();
                        break;

                    case 6:                        
                        Console.WriteLine("Saque\n\n");
                        
                        Console.Write("Digite o número da Conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Digite o valor do Saque: ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        contas.Sacar(numero, valor);

                        KeyPress();
                        break;

                    case 7:                        
                        Console.WriteLine("Depósito\n\n");
                        
                        Console.Write("Digite o número da Conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Digite o valor do Depósito: ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        contas.Depositar(numero, valor);

                        KeyPress();
                        break;

                    case 8:                        
                        Console.WriteLine("Tranferência entre Contas\n\n");
                        
                        Console.Write("Digite o número da Conta de Origem: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Digite o número da Conta de Destino: ");
                        numeroDestino = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Digite o valor da Transferência: ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        contas.Transferir(numero, numeroDestino, valor);

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
        }
        static void KeyPress()
        {
            do
            {
                Console.Write("\nPressione Enter para Continuar...");
                Console.ResetColor();
                consoleKeyInfo = Console.ReadKey();
            }
            while (consoleKeyInfo.Key != ConsoleKey.Enter);



        }
    }
}
        