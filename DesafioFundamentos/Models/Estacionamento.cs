using System;
using System.Collections.Generic;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        // Lista das Placas
        private List<string> listaVeiculos = new List<string>(); 
        // Entrada do veículo
        private Dictionary<string, DateTime> registroHoraEntradaVeiculos = new Dictionary<string, DateTime>(); 
        // Saída do veículo
        private Dictionary<string, DateTime> registroHoraSaidaVeiculos = new Dictionary<string, DateTime>();
        // Valor Final 
        private Dictionary<string, decimal> registroValorFinal = new Dictionary<string, decimal>(); 

        // Método para adicionar o veículo 
        public void AdicionarVeiculo(string placa)
        {
            listaVeiculos.Add(placa);
            registroHoraEntradaVeiculos[placa] = DateTime.Now;
        }

        // Método para remover o veículo 
        public void RemoverVeiculo(string placa)
        {
            if (listaVeiculos.Contains(placa))
            {
                listaVeiculos.Remove(placa);

                registroHoraEntradaVeiculos.Remove(placa);
                registroHoraSaidaVeiculos.Remove(placa);

                registroValorFinal.Remove(placa);
            }
        }

        // Método que lista os veículos
        public void ListarVeiculos()
        {
            if (listaVeiculos.Count > 0)
            {
                Console.WriteLine("Os veículos estacionados:");
                foreach (var placa in listaVeiculos)
                {
                    Console.WriteLine($"Placa: {placa}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        // Definir Valor Final
        public void DefinirPrecoAPagar(string placa, decimal precoAPagar)
        {
            registroValorFinal[placa] = precoAPagar;
        }

        // Calcular o valor a pagar
        public decimal FinalizarVeiculo(string placa)
        {
            decimal valorTotal = 0;

            if (listaVeiculos.Contains(placa) && registroHoraSaidaVeiculos.ContainsKey(placa))
            {
                DateTime horaEntrada = registroHoraEntradaVeiculos[placa];
                DateTime horaSaida = registroHoraSaidaVeiculos[placa];
                TimeSpan permanencia = horaSaida - horaEntrada;
                decimal precoPorHora = registroValorFinal[placa];
                
                valorTotal = precoPorHora * (decimal)permanencia.TotalHours;
                
                RemoverVeiculo(placa);
            }
           
            return valorTotal;
        }

        // Registrar Hora de entrada
        public void HoraEntrada(string placa, DateTime horaEntrada)
        {
            registroHoraEntradaVeiculos[placa] = horaEntrada;
        }

        // Registrar Hora de saída
        public void HoraSaida(string placa, DateTime horaSaida)
        {
            registroHoraSaidaVeiculos[placa] = horaSaida;
        }
    }
}