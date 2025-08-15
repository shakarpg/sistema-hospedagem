# Desafio: Sistema de Hospedagem (DIO - Trilha .NET)

Este repositório contém a solução completa do desafio de projeto do módulo **Explorando a linguagem C#** (DIO).  
O objetivo é modelar um sistema simples de **reservas de hospedagem** com as classes `Pessoa`, `Suite` e `Reserva`.

## Regras do desafio
- **Capacidade**: não é permitido cadastrar mais hóspedes do que a capacidade da suíte. Ex.: suíte para 2 pessoas não pode receber 3.
- **Quantidade de hóspedes**: o método `ObterQuantidadeHospedes()` retorna o total de hóspedes cadastrados na reserva.
- **Valor da diária**: o método `CalcularValorDiaria()` retorna `DiasReservados * ValorDiaria` da suíte.
- **Desconto**: reservas com **10 dias ou mais** recebem **10% de desconto** no valor total.

## Estrutura
```
.
├── DesafioProjetoHospedagem.csproj
├── Program.cs
├── Models
│   ├── Pessoa.cs
│   ├── Suite.cs
│   └── Reserva.cs
└── diagrama_classe_hotel.png
```
As classes estão no namespace `DesafioProjetoHospedagem.Models`.

## Como executar
1. Instale o SDK do .NET 6 ou superior.
2. No diretório do projeto, rode:
   ```bash
   dotnet run
   ```

## Exemplo do `Program.cs`
O `Program.cs` cria dois hóspedes, uma suíte *Premium* com capacidade 2 e diária 30, e uma reserva de 5 dias:
```csharp
List<Pessoa> hospedes = new List<Pessoa> {
    new Pessoa(nome: "Hóspede 1"),
    new Pessoa(nome: "Hóspede 2")
};

Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);
Reserva reserva = new Reserva(diasReservados: 5);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
```

## Tratamento de erros
- Tentar cadastrar mais hóspedes do que a capacidade da suíte lança `InvalidOperationException`.
- Calcular valor sem cadastrar a suíte lança `InvalidOperationException`.
- Entradas inválidas (dias, capacidade, valores) são validadas com exceções apropriadas.

## Diagrama
O diagrama de classes de referência está em `diagrama_classe_hotel.png`.
