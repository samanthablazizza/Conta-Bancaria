﻿using contaBancaria.Model;
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
            throw new NotImplementedException();
        }
        public void Depositar(int numero, decimal valor)
        {
            throw new NotImplementedException();
        }
        public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
        {
            throw new NotImplementedException();
        }

        //Métodos Auxiliares
        public int GerarNumero()
        {
            return ++numero;
        }
        //Método para buscar um Objeto Conta específico
        public Conta BuscarNaCollecion(int numero)
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
