using System;

// Molde para criar filmes
public class Filme
{
    public string Titulo { get; set; }
    public int DuracaoEmMinutos { get; set; }
    public string Genero { get; set; }
}

class Program
{
    public static void Main(string[] args)
    {
        // Criação da lista de filmes em cartaz
        List<Filme> filmes = new List<Filme>();

        // Adicionando alguns filmes de exemplo
        filmes.Add(new Filme { Titulo = "Duna: Parte 2", DuracaoEmMinutos = 166, Genero = "Ficção Científica" });
        filmes.Add(new Filme { Titulo = "Oppenheimer", DuracaoEmMinutos = 180, Genero = "Drama Histórico" });
        filmes.Add(new Filme { Titulo = "Pobres Criaturas", DuracaoEmMinutos = 141, Genero = "Comédia Dramática" });

        bool executando = true;
        while (executando)
        {
            Console.Clear(); // Limpa o console a cada nova exibição do menu
            Console.WriteLine("--- Bem-vindo ao CineSharp ---");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Listar filmes em cartaz");
            Console.WriteLine("2 - Comprar ingresso");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("-----------------------------");
            Console.Write("Digite a opção desejada: ");

            // 1. Aqui lemos a opção que o usuario digitou
            string opcao = Console.ReadLine();

            // 2. Usamos o switch case para tratar a opção escolhida
            switch (opcao)
            {
                case "1":
                    Console.WriteLine("\n--- Filmes em Cartaz ---");

                    // Verificamos se a lista tem algum filme antes de tentar mostrar
                    if (filmes.Count == 0)
                    {
                        Console.WriteLine("Nenhum filme em cartaz no momento.");
                    }
                    else
                    {
                        // Aqui usamos o foreach para percorrer a lista
                        foreach (Filme filme in filmes)
                        {
                            // Para cada filme da lista, mostramos suas informações
                            Console.WriteLine($"Título: {filme.Titulo}");
                            Console.WriteLine($"Gênero: {filme.Genero}");
                            Console.WriteLine($"Duração: {filme.DuracaoEmMinutos}m");
                            Console.WriteLine("--------------------------");
                        }
                    }
                    break;

                case "2":
                    Console.WriteLine("\n--- Comprar Ingresso ---");

                    // --- LOOP DE ESCOLHA DO FILME ---
                    Filme filmeEscolhido = null; // Declaramos a variável aqui fora
                    while (filmeEscolhido == null)
                    {
                        Console.WriteLine("\nPara qual filme você gostaria de comprar um ingresso?");
                        for (int i = 0; i < filmes.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {filmes[i].Titulo}");
                        }
                        Console.Write("\nDigite o número do filme: ");

                        if (int.TryParse(Console.ReadLine(), out int numeroFilme) && numeroFilme > 0 && numeroFilme <= filmes.Count)
                        {
                            filmeEscolhido = filmes[numeroFilme - 1]; // Atribui o filme e quebra o loop
                            break; // Sai do loop de escolha do filme
                        }
                        else
                        {
                            Console.WriteLine("\nOpção inválida! Por favor, digite um número da lista.");
                            Console.WriteLine("\nPressione qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                    }

                    double precoFinal = 0;

                    // --- LOOP DE ESCOLHA DO TIPO DE INGRESSO ---
                    while (true)
                    {
                        Console.Write("\nO ingresso é (1) Inteira [R$30,00] ou (2) Meia [R$15,00]? Digite o número: ");
                        string tipoIngresso = Console.ReadLine();
                        if (tipoIngresso == "1")
                        {
                            precoFinal += 30.00;
                            break; // Sai do loop
                        }
                        else if (tipoIngresso == "2")
                        {
                            precoFinal += 15.00;
                            break; // Sai do loop
                        }
                        else
                        {
                            Console.WriteLine("\nOpção inválida! Por favor, digite 1 ou 2.");
                            Console.WriteLine("\nPressione qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                    }

                    // --- LOOP DE ESCOLHA DO TIPO DE SALA ---
                    while (true)
                    {
                        Console.Write("\nA sala é (1) 2D [+ R$0,00] ou (2) 3D [+ R$8,00]? Digite o número: ");
                        string tipoSala = Console.ReadLine();
                        if (tipoSala == "1")
                        {
                            // Nenhum custo adicional
                            break; // Sai do loop
                        }
                        else if (tipoSala == "2")
                        {
                            precoFinal += 8.00;
                            break; // Sai do loop
                        }
                        else
                        {
                            Console.WriteLine("\nOpção inválida! Por favor, digite 1 ou 2.");
                        }
                    }

                    // --- EXIBIÇÃO DO RESUMO ---
                    Console.WriteLine("\n--- Resumo da Compra ---");
                    Console.WriteLine($"Filme: {filmeEscolhido.Titulo}");
                    Console.WriteLine($"Total a pagar: R$ {precoFinal:F2}");

                    break; // Break final do switch case "2"

                case "0":
                    executando = false; // Alteramos a variável para false para sair do loop
                    Console.WriteLine("\nAgradecemos pela preferrencia, o CineSharp estará sempre à disposição.");
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    break;
            }

            // Uma pequena pausa para o usuário poder ler a mensagem
            // antes do console limpar novamente.
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
