using CRUD;
using System;
using System.Collections.Generic;

namespace CRUDContas
{
    class Program
    {
        // Lista que vai armazenar as contas em memória
        static List<ContaCorrente> contas = new List<ContaCorrente>();

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.Clear();

                Console.WriteLine("=================================");
                Console.WriteLine("       CRUD - CONTA CORRENTE");
                Console.WriteLine("=================================");
                Console.WriteLine("1 - Cadastrar conta");
                Console.WriteLine("2 - Listar contas");
                Console.WriteLine("3 - Consultar conta");
                Console.WriteLine("4 - Alterar conta");
                Console.WriteLine("5 - Excluir conta");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("=================================");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("\nOpção inválida!");
                    Console.ReadKey();
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        Cadastrar();
                        break;

                    case 2:
                        Listar();
                        break;

                    case 3:
                        Consultar();
                        break;

                    case 4:
                        Alterar();
                        break;

                    case 5:
                        Excluir();
                        break;

                    case 0:
                        Console.WriteLine("\nPrograma encerrado.");
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida!");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }

        static void Cadastrar()
        {
            Console.Clear();
            Console.WriteLine("===== CADASTRAR CONTA =====\n");

            Console.Write("Número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            ContaCorrente contaExistente = contas.Find(c => c.Numero == numero);

            if (contaExistente != null)
            {
                Console.WriteLine("\nJá existe uma conta com esse número.");
                return;
            }

            Console.Write("Nome do titular: ");
            string titular = Console.ReadLine();

            Console.Write("Tipo da conta: ");
            string tipoConta = Console.ReadLine();

            Console.Write("Saldo inicial: ");
            decimal saldo = decimal.Parse(Console.ReadLine());

            ContaCorrente novaConta = new ContaCorrente(
                numero,
                titular,
                tipoConta,
                saldo
            );

            contas.Add(novaConta);

            Console.WriteLine("\nConta cadastrada com sucesso!");
        }

        static void Listar()
        {
            Console.Clear();
            Console.WriteLine("===== LISTA DE CONTAS =====\n");

            if (contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            foreach (ContaCorrente conta in contas)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Número:     {conta.Numero}");
                Console.WriteLine($"Titular:    {conta.Titular}");
                Console.WriteLine($"Tipo:       {conta.TipoConta}");
                Console.WriteLine($"Saldo:      R$ {conta.Saldo:F2}");
            }

            Console.WriteLine("---------------------------------");
        }

        static void Consultar()
        {
            Console.Clear();
            Console.WriteLine("===== CONSULTAR CONTA =====\n");

            Console.Write("Digite o número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            ContaCorrente conta = contas.Find(c => c.Numero == numero);

            if (conta == null)
            {
                Console.WriteLine("\nConta não encontrada.");
                return;
            }

            Console.WriteLine("\nConta encontrada!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Número:     {conta.Numero}");
            Console.WriteLine($"Titular:    {conta.Titular}");
            Console.WriteLine($"Tipo:       {conta.TipoConta}");
            Console.WriteLine($"Saldo:      R$ {conta.Saldo:F2}");
            Console.WriteLine("---------------------------------");
        }

        static void Alterar()
        {
            Console.Clear();
            Console.WriteLine("===== ALTERAR CONTA =====\n");

            Console.Write("Digite o número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            ContaCorrente conta = contas.Find(c => c.Numero == numero);

            if (conta == null)
            {
                Console.WriteLine("\nConta não encontrada.");
                return;
            }

            Console.WriteLine("\nConta encontrada.");

            Console.WriteLine($"Titular atual: {conta.Titular}");
            Console.Write("Novo titular: ");
            conta.Titular = Console.ReadLine();

            Console.WriteLine($"Tipo atual: {conta.TipoConta}");
            Console.Write("Novo tipo: ");
            conta.TipoConta = Console.ReadLine();


            Console.WriteLine("\nConta alterada com sucesso!");
        }

        static void Excluir()
        {
            Console.Clear();
            Console.WriteLine("===== EXCLUIR CONTA =====\n");

            Console.Write("Digite o número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            ContaCorrente conta = contas.Find(c => c.Numero == numero);

            if (conta == null)
            {
                Console.WriteLine("\nConta não encontrada.");
                return;
            }

            Console.WriteLine($"\nTitular: {conta.Titular}");
            Console.Write("Deseja realmente excluir? (S/N): ");

            string resposta = Console.ReadLine();

            if (resposta.ToUpper() == "S")
            {
                contas.Remove(conta);
                Console.WriteLine("\nConta excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("\nExclusão cancelada.");
            }
        }
    }
}