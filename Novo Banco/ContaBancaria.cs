using System;
using System.Collections.Generic;
using System.Text;

namespace Novo_Banco
{
    class ContaBancaria
    {
        public string Conta { get; }//000862
        public string Nome { get; set; } //Hericson Ramos
        public decimal Saldo { get {
                                    decimal saldo = 0;
                                    foreach (var item in todasTranscoes)
                                    {
                                        saldo += item.Valor;
                                    }
                                    return saldo;
                                } 
       }

        private static int NumeroSequencia = 86600;

        protected List<Transacao> todasTranscoes = new List<Transacao>();
        
        public ContaBancaria(string nome, decimal valorInicial)
        {
            this.Nome = nome;
            
            this.Conta = NumeroSequencia.ToString();
            NumeroSequencia++;

            Deposito(valorInicial, DateTime.Now, "Deposito Inicial");
        }

        public ContaBancaria()
        {
        }

        public void Deposito(decimal valor, DateTime data, string obs){
           if(valor > 0){
                var deposito = new Transacao(valor, data, obs);
                todasTranscoes.Add(deposito);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "O deposito deve ser positivo");
            }
        }

        public virtual void Saque(decimal valor, DateTime data, string obs)
        {
            if (valor > 0 &&  valor <= this.Saldo)
            {
                var saque = new Transacao(-valor, data, obs);
                todasTranscoes.Add(saque);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "o valor do saque nao pode ser 0(zero) e nao pode ser maior que o saldo");
            }
        }

        public virtual string Extrato()
        {
            var extrato = new System.Text.StringBuilder();
            decimal total = 0;
            extrato.AppendLine("Data\t\tValor\ttotal\tOperação");
            foreach(var item in todasTranscoes)
            {
                total += item.Valor;
                extrato.AppendLine($"{item.Data.ToShortDateString()}\t{item.Valor}\t{total}\t{item.Obs}");
            }
            return extrato.ToString();
        }
    }
}
