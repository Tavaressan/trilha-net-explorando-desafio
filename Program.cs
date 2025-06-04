using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// // Cria os modelos de hóspedes e cadastra na lista de hóspedes
// List<Pessoa> hospedes = new List<Pessoa>();

// Pessoa p1 = new Pessoa(nome: "Hóspede 1");
// Pessoa p2 = new Pessoa(nome: "Hóspede 2");

// hospedes.Add(p1);
// hospedes.Add(p2);

// // Cria a suíte
// Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// // Cria uma nova reserva, passando a suíte e os hóspedes
// Reserva reserva = new Reserva(diasReservados: 5);
// reserva.CadastrarSuite(suite);
// reserva.CadastrarHospedes(hospedes);

// // Exibe a quantidade de hóspedes e o valor da diária
// Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
// Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");


////////////////////////////////// Menu criado para usar o sistema.


string tipoSuite = string.Empty;
decimal valorDiaria = 0;
int capacidade = 0;
decimal quantHospedes = 0;
int diasReservados = 0;


Console.WriteLine("Seja bem vindo ao sistema de Hospedagem!\n" +
                  "Digite o tipo da suite:");

tipoSuite = Convert.ToString(Console.ReadLine());

Console.WriteLine("Agora digite o valor da diária:");
valorDiaria = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite a capacidade da suíte:");
capacidade = Convert.ToInt32(Console.ReadLine());

// Instancia a classe Suite, já com os valores obtidos anteriormente
Suite suite = new Suite(tipoSuite, capacidade, valorDiaria);

// Instancia a classe Reserva antes de receber a quantidade de dias reservados
Reserva reserva = new Reserva(diasReservados: 0);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Criar reserva");
    Console.WriteLine("2 - Listar quantidade de hóspedes e valor da diária");
    Console.WriteLine("3 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            List<Pessoa> hospedes = new List<Pessoa>();
            // string idHospede = string.Empty;
            string nomeHospede = string.Empty;
            string sobrenomeHospede = string.Empty;

            Console.WriteLine("Quantos hóspedes para esta reserva?");
            quantHospedes = Convert.ToDecimal(Console.ReadLine());

            for (int i = 0; i < quantHospedes; i++)
            {
                Console.WriteLine("Digite o nome completo do hóspede:");
                string[] nomeCompleto = Console.ReadLine().Split(' ');
                nomeHospede = nomeCompleto[0];
                sobrenomeHospede = string.Join(" ", nomeCompleto.Skip(1));

                Pessoa pessoa = new Pessoa(nomeHospede, sobrenomeHospede);
                hospedes.Add(pessoa);
            }

            // Cria uma nova reserva, passando a suíte e os hóspedes
            Console.WriteLine("Por quantos dias será feita a reserva? (Temos 10% de desconto a partir de 10 dias)");

            diasReservados = Convert.ToInt32(Console.ReadLine());
            reserva.DiasReservados = diasReservados;
            // Reserva reserva = new Reserva(diasReservados);

            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);

            Console.WriteLine("Cadastro feito com sucesso!");
            break;

        case "2":
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor diária: U$ {reserva.CalcularValorDiaria()}");
            break;

        case "3":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");