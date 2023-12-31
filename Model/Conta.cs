﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contaBancaria.Model
{
    public abstract class Conta //classe ABSTRATA
    {
        /*Atributos*/
        private int numero;
        private int agencia;
        private int tipo;
        private string titular = string.Empty;
        private decimal saldo;

        /*Método Construtor */
        public Conta(int numero, int agencia, int tipo, string titular, decimal saldo)
        {
            this.numero = numero;
            this.agencia = agencia;
            this.tipo = tipo;
            this.titular = titular;
            this.saldo = saldo;
        }
        public Conta() { }//Poliformismo de Sobrecarga

        /*Métodos Get e Set*/
        public int GetNumero()//o Método Get é usado para exibir o conteúdo, caso não queira exibir é só não criá-lo
        {
            return numero;
        }

        public void SetNumero(int numero)//No método Set o conteúdo pode ser alterado,
        {
            this.numero = numero;
        }

        public int GetAgencia()
        {
            return agencia;
        }

        public void SetAgencia(int agencia)
        {
            this.agencia = agencia;
        }

        public int GetTipo()
        {
            return tipo;
        }

        public void SetTipo(int tipo)
        {
            this.tipo = tipo;
        }

        public string GetTitular()
        {
            return titular;
        }

        public void SetTitular(string titular)
        {
            this.titular = titular;
        }

        public decimal GetSaldo()
        {
            return saldo;
        }

        public void SetSaldo(decimal saldo)
        {
            this.saldo = saldo;
        }
        public virtual bool Sacar(decimal valor)
        {
            if (this.saldo < valor)
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            this.SetSaldo(this.saldo - valor);
            return true;
        }

        public void Depositar(decimal valor)
        {
            this.SetSaldo(this.saldo + valor);
        }


        public virtual void Visualizar()
        {
            string tipo = "";

            switch (this.tipo)
            {
                case 1:
                    tipo = "Conta Corrente";
                    break;

                case 2:
                    tipo = "Conta Poupança";
                    break;
            }

            Console.WriteLine("************************************");
            Console.WriteLine("Dados da Conta");
            Console.WriteLine("************************************");
            Console.WriteLine($"Número da conta: {this.numero}");
            Console.WriteLine($"Número da agência: {this.agencia}");
            Console.WriteLine($"Tipo da conta: {this.tipo}");
            Console.WriteLine($"Titular: {this.titular}");
            Console.WriteLine($"Saldo: " + (this.saldo).ToString("C"));
        }
    }
}
