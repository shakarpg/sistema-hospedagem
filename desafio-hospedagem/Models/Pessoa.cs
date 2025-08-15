using System;

namespace DesafioProjetoHospedagem.Models
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public string NomeCompleto => $"{Nome} {Sobrenome}".Trim();

        public Pessoa() { }

        public Pessoa(string nome, string sobrenome = "")
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do hóspede não pode ser vazio.", nameof(nome));

            Nome = nome;
            Sobrenome = sobrenome ?? string.Empty;
        }

        public override string ToString() => NomeCompleto;
    }
}
