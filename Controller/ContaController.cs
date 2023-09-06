using contaBancaria.Model;
using contaBancaria.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contaBancaria.Controller
{
    public class ContaController : IcontaRepository
    {
        private readonly List<Conta> listaContas = new();
        int numero = 0;

        //Métodos do CRUD
        public void Atualizar(Conta conta)
        {
            var buscaconta = BuscarNaCollecion(conta.GetNumero());  

            if (buscaconta != null)
            {
                var index = listaContas.IndexOf(buscaconta);

                listaContas[index] = conta;

                Console.WriteLine($"A conta {conta.GetNumero()} foi atualizada com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta {numero} não foi encontrada!");
                Console.ResetColor();
            }            
        }
        public void Cadastrar(Conta conta)
        {
            listaContas.Add(conta);
            Console.WriteLine($"A conta número {conta.GetNumero()} foi criada com sucesso!");
        }

        public void Deletar(int numero)
        {
            var conta = BuscarNaCollecion(numero);

            if (conta is not null)
            {

                if (listaContas.Remove(conta) == true)
                    Console.WriteLine($"A Conta {numero} foi apagada com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }
        public void ListarTodas()
        {
            foreach (var conta in listaContas)
            {
                conta.Visualizar();
            }
        }
        public void ProcurarPorNumero(int numero)
        {
            var conta = BuscarNaCollecion(numero);

            if (conta is not null)
                conta.Visualizar();
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }
        //Métodos Bancários
        public void Sacar(int numero, decimal valor)
        {
            var conta = BuscarNaCollecion(numero);

            if (conta is not null)
            {
               if (conta.Sacar(valor) == true)
                    Console.WriteLine($"O Saque na conta {numero} foi efetuado com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta {numero} não foi encontrada!");
                Console.ResetColor();
            }
         }
        public void Depositar(int numero, decimal valor)
        {
            var conta = BuscarNaCollecion(numero);

            if (conta is not null)
            {
                conta.Depositar(valor);
                    Console.WriteLine($"O Depósito na conta {numero} foi efetuado com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta {numero} não foi encontrada!");
                Console.ResetColor();
            }
        }
        public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
        {
            var contaOrigem = BuscarNaCollecion(numeroOrigem);
            var contaDestino = BuscarNaCollecion(numeroDestino);

            if (contaOrigem is not null && contaDestino is not null)
            {
                if (contaOrigem.Sacar(valor) == true)
                {
                    contaDestino.Depositar(valor);
                    Console.WriteLine($"O Transferência foi efetuada com sucesso!");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"A conta de Origem e/ou Conta de Destino não foram encontradas!");
                Console.ResetColor();
            }
        }
        //Métodos Auxiliares
        public int GerarNumero()
        {
            return ++numero;
        }
        //Método para buscar um Objeto Conta específico
        public Conta? BuscarNaCollecion(int numero)
        {
            foreach(var conta in listaContas)
            {
                if (conta.GetNumero() == numero)
                    return conta;
            }
            return null;
        }
    }
}
