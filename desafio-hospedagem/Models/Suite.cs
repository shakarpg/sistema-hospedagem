using System;

namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }

        public Suite() { }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            if (string.IsNullOrWhiteSpace(tipoSuite))
                throw new ArgumentException("O tipo da suíte é obrigatório.", nameof(tipoSuite));
            if (capacidade <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacidade), "A capacidade deve ser maior que zero.");
            if (valorDiaria <= 0)
                throw new ArgumentOutOfRangeException(nameof(valorDiaria), "O valor da diária deve ser maior que zero.");

            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        public override string ToString() => $"{TipoSuite} (capacidade: {Capacidade}, diária: {ValorDiaria:C})";
    }
}
