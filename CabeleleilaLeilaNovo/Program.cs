using Base.Repository;
using CabeleleilaLeilaNovo.Controllers;
using CabeleleilaLeilaNovo.Models;
using Models.Agendamento;
using Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CabeleleilaLeilaNovo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var usuarioController = new UsuarioController();
            UsuarioModel usuarioModel = new UsuarioModel();
            ProcedimentoController procedimentoController = new ProcedimentoController();
            AgendamentoController agendamentoController = new AgendamentoController();
            AgendamentoModel agendamentoModel = new AgendamentoModel();

            Console.WriteLine("1-Para efetuar cadastro");
            Console.WriteLine("2-Para efetuar login");
            var entrada = Console.ReadLine();
            
            try
            {
                switch (int.Parse(entrada))
                {
                    case 1:
                        {
                            Console.WriteLine("Informe o nome: \n");
                            usuarioModel.Nome = Console.ReadLine();
                            Console.WriteLine("Informe o endereço: \n");
                            usuarioModel.Endereco = Console.ReadLine();
                            Console.WriteLine("Informe o telefone com o DDD: \n");
                            usuarioModel.Telefone = Console.ReadLine();
                            Console.WriteLine("Informe seu Login: \n");
                            usuarioModel.Login = Console.ReadLine();
                            Console.WriteLine("Senha: \n");
                            usuarioModel.Senha = Console.ReadLine();
                            usuarioModel.IdTipo = 2;

                            usuarioController.Cadastrar(usuarioModel);
                            if (usuarioModel.Id != 0)
                            {
                                Console.WriteLine($"Usuário {usuarioModel.Nome} cadastrado(a) com sucesso!");
                                Console.WriteLine();
                                Menu();
                                var escolha2= Console.ReadLine();
                                switch (int.Parse(escolha2))
                                {
                                    case 1:
                                        agendamentoModel.IdProcedimento = ListaProcedimento();

                                        try
                                        {
                                            while (true)
                                            {
                                                Console.WriteLine("Digite a data desejada(formato americano)");
                                                agendamentoModel.Data = Console.ReadLine();
                                                if (!Regex.IsMatch(agendamentoModel.Data, "[2][0][2][2-5][-][0][1-9][-][0-2][0-9]")
                                                    && !Regex.IsMatch(agendamentoModel.Data, "[2][0][2][2-5][-][1][0-2][-][0-2][0-9]")
                                                    && !Regex.IsMatch(agendamentoModel.Data, "[2][0][2][2-5][-][0][1-9][-][3][0-1]")
                                                    && !Regex.IsMatch(agendamentoModel.Data, "[2][0][2][2-5][-][1][0-2][-][3][0-1]"))
                                                {
                                                    Console.WriteLine("Data inválida !!");
                                                    Console.WriteLine("Ex: 2022-04-28");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Digite o horário desejado");
                                                    agendamentoModel.Hora = Console.ReadLine();
                                                    if (!Regex.IsMatch(agendamentoModel.Hora, "[0-1][0-9][:][0-5][0-9]"))
                                                    {
                                                        Console.WriteLine("Hora inválida !!");
                                                        Console.WriteLine("Ex: 15:30");
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }

                                            }
                                            agendamentoController.Cadastrar(agendamentoModel);

                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        break;

                                }

                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Informe seu Login: \n");
                            usuarioModel.Login = Console.ReadLine();
                            Console.WriteLine("Senha: \n");
                            usuarioModel.Senha = Console.ReadLine();
                            UsuarioModel usuario= usuarioController.Login(usuarioModel.Login, usuarioModel.Senha);
                            if (usuario.Id != 0)
                            {
                                Console.WriteLine($"Usuário {usuarioModel.Nome} logado(a) com sucesso!");
                                Console.WriteLine();
                                Menu();
                                var escolha2 = Console.ReadLine();
                                switch (int.Parse(escolha2))
                                {
                                    case 1:
                                        agendamentoModel.IdProcedimento = ListaProcedimento();

                                        try
                                        {
                                            while (true)
                                            {
                                                Console.WriteLine("Digite a data desejada(formato americano)");
                                                agendamentoModel.Data = Console.ReadLine();
                                                if (!Regex.IsMatch(agendamentoModel.Data, "[2][0][2][2-5][-][0][1-9][-][0-2][0-9]")
                                                    && !Regex.IsMatch(agendamentoModel.Data, "[2][0][2][2-5][-][1][0-2][-][0-2][0-9]")
                                                    && !Regex.IsMatch(agendamentoModel.Data, "[2][0][2][2-5][-][0][1-9][-][3][0-1]")
                                                    && !Regex.IsMatch(agendamentoModel.Data, "[2][0][2][2-5][-][1][0-2][-][3][0-1]"))
                                                {
                                                    Console.WriteLine("Data inválida !!");
                                                    Console.WriteLine("Ex: 2022-04-28");
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            while(true)
                                            {
                                                Console.WriteLine("Digite o horário desejado");
                                                agendamentoModel.Hora = Console.ReadLine();
                                                if (!Regex.IsMatch(agendamentoModel.Hora, "[0-1][0-9][:][0-5][0-9]"))
                                                {
                                                    Console.WriteLine("Hora inválida !!");
                                                    Console.WriteLine("Ex: 15:30");
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                            agendamentoModel.IdCliente = usuario.Id;
                                            agendamentoController.Cadastrar(agendamentoModel);

                                        }
                                        catch(Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        break;

                                }


                            }
                            break;
                        }
                    default:
                        Console.WriteLine("Opção inválida");
                        break;

                }
            }
            catch 
            {
                Console.WriteLine("Opção inválida!!!!");
            }

        }
        public static void Menu()
        {
            Console.WriteLine("1-Agendar Procediemnto");
            Console.WriteLine("2-Alterar Agendamento");
            Console.WriteLine("3-Listar Agendamentos");
            
        }
        public static int ListaProcedimento()
        {
            ProcedimentoController procedimentoController = new ProcedimentoController();
            Console.WriteLine("Escolha dentre os procedimentos");
            var lstProcedimento = procedimentoController.Listar();
            foreach (var item in lstProcedimento)
            {
                Console.WriteLine($"Id:{item.Id}\tProcedimento:{item.Procedimento}\tValor:{item.Valor}");
            }

            int procedimento = 0;
            while (true)
            {
                Console.WriteLine("Digite o código do procedimento desejado");
                procedimento = int.Parse(Console.ReadLine());
                
                if (lstProcedimento.Where(p => p.Id == procedimento).Any())
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Código do procedimento inválido!");
                }
                
            }
            return procedimento;
        }
    }
}
