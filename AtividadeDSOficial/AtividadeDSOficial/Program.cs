using AppBancoDLL;
using AppBancoDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeDSOficial
{
    public class Program
    {
        static void Main(string[] args)
        {
            var usuarioDAO = new UsuarioDAO();
            bool repetir = true;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("\n\r-----------BEM VINDO-----------\n\r");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(
                "\n\r* 0 - CADASTRAR usuário \n" +
                "\n\r* 1 - EDITAR usuário \n" +
                "\n\r* 2 - EXCLUIR usuário \n" +
                "\n\r* 3 - LISTAR usuários \n" +
                "\n\r* 4 - SAIR \r\n");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("\n\r-------------------------------\n\r");

            while (repetir)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Qual opção você deseja?");
                Console.ForegroundColor = ConsoleColor.Red;
                var resposta = Console.ReadLine();

                repetir = false;
                switch (resposta)
                {
                    case "0":
                        CadastrarUsuarios(usuarioDAO);
                        ListarUsuarios(usuarioDAO);
                        break;

                    case "1":
                        EditarUsuarios(usuarioDAO);
                        ListarUsuarios(usuarioDAO);
                        break;

                    case "2":
                        DeletarUsuarios(usuarioDAO);
                        ListarUsuarios(usuarioDAO);
                        break;

                    case "3":
                        ListarUsuarios(usuarioDAO);
                        break;

                    case "4":
                        Environment.Exit(0);
                        break;

                    default:
                        repetir = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Prescione o enter e escolha uma das opções: 0,1,2,3 ou 4. \r\n");
                        break;
                }
            }
        }

        private static void ListarUsuarios(UsuarioDAO usuarioDAO)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            var leitor = usuarioDAO.Listar();
            foreach (var usuarios in leitor)
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Data: {3}", usuarios.IdUsu, usuarios.NomeUsu, usuarios.Cargo, usuarios.DataNasc);
            }
            Console.ReadLine();
        }

        private static void CadastrarUsuarios(UsuarioDAO usuarioDAO)
        { 
            var usuario = new Usuario();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Digite o nome do usuário:");
            Console.ForegroundColor = ConsoleColor.Red;
            usuario.NomeUsu = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Digite o cargo do usuário:");
            Console.ForegroundColor = ConsoleColor.Red;
            usuario.Cargo = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Digite a data de nascimento do usuário:");
            Console.ForegroundColor = ConsoleColor.Red;
            usuario.DataNasc = DateTime.Parse(Console.ReadLine());

            usuarioDAO.Salvar(usuario);
        }

        private static void EditarUsuarios(UsuarioDAO usuarioDAO)
        {
            var usuario = new Usuario();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Digite o id que deseja alterar:");
            Console.ForegroundColor = ConsoleColor.Red;
            usuario.IdUsu = Convert.ToInt32(Console.ReadLine());

            if (usuario.IdUsu > 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Digite o nome do usuário:");
                Console.ForegroundColor = ConsoleColor.Red;
                usuario.NomeUsu = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Digite o cargo do usuário:");
                Console.ForegroundColor = ConsoleColor.Red;
                usuario.Cargo = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Digite a data de nascimento do usuário:");
                Console.ForegroundColor = ConsoleColor.Red;
                usuario.DataNasc = DateTime.Parse(Console.ReadLine());

                usuarioDAO.Atualizar(usuario);
            }
        }
        public static void DeletarUsuarios(UsuarioDAO usuarioDAO)
        {
            var usuario = new Usuario();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Digite o id que deseja excluir:");
            Console.ForegroundColor = ConsoleColor.Red;
            usuario.IdUsu = Convert.ToInt32(Console.ReadLine());

            if (usuario.IdUsu > 0)
            {
                usuarioDAO.Excluir(usuario);
            }
        }
    }
}
