using System;
using System.Collections.Generic;




namespace DesafioFundamentos

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Seja bem-vindo ao sistema de estacionamento");

            Console.Write("Digite o preço inicial: ");
            decimal precoInicial = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Agora, digite o preço por hora (preço de cada hora de permanência): ");
            decimal precoPorHora = Convert.ToDecimal(Console.ReadLine());

            // Instancia a classe Estacionamento, já com os valores obtidos anteriormente

            Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

            int opcao;

            // Realiza o loop do menu
            do
            {
                Console.WriteLine("\n------Menu------");
                Console.WriteLine("Digite a sua opção:");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Encerrar");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            Console.Write("Digite a placa do veículo: ");
                            string placa = Console.ReadLine();

                            estacionamento.CadastrarVeiculo(placa);
                            Console.WriteLine("Veículo cadastrado com sucesso.");
                            break;

                        case 2:
                            Console.Write("Digite a placa do veículo para remover: ");
                            string placaRemover = Console.ReadLine();

                            Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                            int horasPermanencia = Convert.ToInt32(Console.ReadLine());

                            decimal precoTotal = estacionamento.RemoverVeiculo(placaRemover, horasPermanencia);

                            Console.WriteLine("Veículo saiu do Estacionamento.\nValor total: R$" + precoTotal);
                            break;

                        case 3:
                            Console.WriteLine("Os veículos estacionados são:\n");

                            List<string> veiculos = estacionamento.ListarVeiculos();
                            foreach (var veiculo in veiculos)
                            {
                                Console.WriteLine(veiculo);
                            }
                            break;

                        case 4:
                            Console.WriteLine("O programa se encerrou");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                }
            } while (opcao != 4);

            Console.WriteLine("Pressione qualquer tecla para continuar.");
        }
    }

    class Estacionamento

    {
        

        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void CadastrarVeiculo(string placa)
        {
            veiculos.Add(placa);
        }

        public decimal RemoverVeiculo(string placa, int horasPermanencia)
        {
            if (veiculos.Contains(placa))
            {
                veiculos.Remove(placa);
                return precoInicial + (precoPorHora * horasPermanencia);
            }
            return 0;
        }

        public List<string> ListarVeiculos()
        {
            return veiculos;
        }
    }
}
