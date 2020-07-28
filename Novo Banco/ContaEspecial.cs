using System;
using System.Collections.Generic;
using System.Text;

namespace Novo_Banco
{
    
     class ContaEspecial : ContaBancaria
    {
        public decimal Limite { get; private set; }
        public ContaEspecial(string nome, decimal valorInicial,decimal Limite) : base(nome, valorInicial)
        {
            this.Limite = Limite;
        }
        public override void Saque(decimal valor, DateTime data, string obs)
        {
            if (valor > 0 && valor <= (this.Saldo + this.Limite))
            {
                var saque = new Transacao(-valor, data, obs);
                todasTranscoes.Add(saque);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "o valor do saque nao pode ser 0(zero) e nao pode ser maior que o saldo");
            }
        }

        public override string Extrato()
        {
            var extrato = new System.Text.StringBuilder();
            decimal total = 0;
            extrato.AppendLine("Data\t\tValor\ttotal\tOperação");
            foreach (var item in todasTranscoes)
            {
                total += item.Valor;
                extrato.AppendLine($"{item.Data.ToShortDateString()}\t{item.Valor}\t{total}\t{item.Obs}\t{this.Limite}");
            }
            return extrato.ToString();
        }
    }
}
