using System;
using System.Collections.Generic;

namespace ProgramaEstacionamento
{
    class Estacionamento
    {
        // Lista das Placas
        private List<string> veiculos = new List<string>(); 
        // Entrada do veículo
        private Dictionary<string, DateTime> horaEntradaVeiculos = new Dictionary<string, DateTime>(); 
        //Saída do veículo
        private Dictionary<string, DateTime> horaSaidaVeiculos = new Dictionary<string, DateTime>();
        // Valor Final 
        private Dictionary<string, decimal> valorFinal = new Dictionary<string, decimal>(); 

        // Método para adicionar o veículo 

        public void AdicionarVeiculo(string placa)
        {
            veiculos.Add(placa);
            horaEntradaVeiculos[placa] = DateTime.Now;
        }

        // Método para remover o veículo 
        
        public void RemoverVeiculo(string placa)
        {
            if (veiculos.Contains(placa))
            {
                veiculos.Remove(placa);

                horaEntradaVeiculos.Remove(placa);
                horaSaidaVeiculos.Remove(placa);

                valorFinal.Remove(placa);
            }
        }

        // Método que lista os veículos
        public void ListarVeiculos()
        {
            Console.WriteLine("Os veículos estacionados:");
            foreach (var placa in veiculos)
            {
                Console.WriteLine($"Placa: {placa}");
            }
        }

        // Método que registra a hora de entrada
        public void RegistrarHoraEntrada(string placa, DateTime horaEntrada)

        {
            horaEntradaVeiculos[placa] = horaEntrada;
        }

        // Método que registra a hora de saída
        public void RegistrarHoraSaida(string placa, DateTime horaSaida)

        {
            horaSaidaVeiculos[placa] = horaSaida;
        }

        // Valor Final
        public void DefinirPrecoAPagar(string placa, decimal precoAPagar)

        {

            valorFinal[placa] = precoAPagar;

        }

        // Calcular o valor a pagar
        public decimal FinalizarVeiculo(string placa)
{
    decimal precoTotal = 0;

    if (veiculos.Contains(placa) && horaSaidaVeiculos.ContainsKey(placa))
    {
        DateTime horaEntrada = horaEntradaVeiculos[placa];
        DateTime horaSaida = horaSaidaVeiculos[placa];
        TimeSpan permanencia = horaSaida - horaEntrada;
        decimal precoPorHora = valorFinal[placa];

        precoTotal = precoPorHora * (decimal)permanencia.TotalHours;

        // Formatar o valor total em reais
        string valorFormatado = precoTotal.ToString("C");

        // Converte o valor formatado de volta para decimal
        decimal precoTotalFormatado = decimal.Parse(valorFormatado);

        // Remover o veículo
        RemoverVeiculo(placa);

        return precoTotalFormatado;
    }

    return precoTotal;
}
    }
}