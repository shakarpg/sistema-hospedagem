using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; private set; } = new List<Pessoa>();
        public Suite Suite { get; private set; }
        public int DiasReservados { get; private set; }

        public Reserva(int diasReservados)
        {
            if (diasReservados <= 0)
                throw new ArgumentOutOfRangeException(nameof(diasReservados), "Dias reservados deve ser maior que zero.");
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null)
                throw new InvalidOperationException("Cadastre a suíte antes de cadastrar os hóspedes.");
            if (hospedes == null || hospedes.Count == 0)
                throw new ArgumentException("A lista de hóspedes não pode ser vazia.", nameof(hospedes));
            if (hospedes.Count > Suite.Capacidade)
                throw new InvalidOperationException($"Capacidade excedida: a suíte comporta {Suite.Capacidade} hóspede(s), mas foram informados {hospedes.Count}.");

            Hospedes = new List<Pessoa>(hospedes);
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite ?? throw new ArgumentNullException(nameof(suite));
        }

        public int ObterQuantidadeHospedes() => Hospedes?.Count ?? 0;

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
                throw new InvalidOperationException("É necessário cadastrar a suíte para calcular o valor da diária.");

            decimal valor = DiasReservados * Suite.ValorDiaria;
            if (DiasReservados >= 10)
                valor *= 0.90m; // desconto de 10%

            return valor;
        }
    }
}
