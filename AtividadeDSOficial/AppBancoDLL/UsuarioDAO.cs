using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppBancoADO;
using AppBancoDominio;
using MySql.Data.MySqlClient;

namespace AppBancoDLL
{
    public class UsuarioDAO
    {
        private Banco db;

        public void Insert(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "INSERT INTO tbUsuario(NomeUsu, Cargo, DataNasc)";
            strQuery += string.Format("Values('{0}', '{1}', STR_TO_DATE('{2}', '%d/%m/%Y %T'));", usuario.NomeUsu, usuario.Cargo, usuario.DataNasc);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void Atualizar(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "UPDATE tbUsuario SET ";
            strQuery += string.Format("NomeUsu = '{0}', ", usuario.NomeUsu);
            strQuery += string.Format("Cargo = '{0}', ", usuario.Cargo);
            strQuery += string.Format("DataNasc = STR_TO_DATE('{0}', '%d/%m/%Y %T')", usuario.DataNasc);
            strQuery += string.Format("WHERE IdUsu = {0};", usuario.IdUsu);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Usuario usuario)
        {
            if (usuario.IdUsu > 0)
            {
                Atualizar(usuario);
            }
            else
            {
                Insert(usuario);
            }
        }

        public void Excluir(Usuario usuario)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("DELETE FROM tbUsuario WHERE IdUSu = {0}", usuario.IdUsu);
                db.ExecutaComando(strQuery);
            }
        }

        public List<Usuario> Listar()
        {
            using (db = new Banco())
            {
                var strQuery = "SELECT * FROM tbUsuario";
                var retorno = db.RetornaComando(strQuery);
                return ListaDeUsuario(retorno);
            }
        }

        public List<Usuario> ListaDeUsuario(MySqlDataReader retorno)
        {
            var usuarios = new List<Usuario>();
            while (retorno.Read())
            {
                var TempUsuario = new Usuario()
                {
                    IdUsu = int.Parse(retorno["IdUsu"].ToString()),
                    NomeUsu = retorno["NomeUsu"].ToString(),
                    Cargo = retorno["Cargo"].ToString(),
                    DataNasc = DateTime.Parse(retorno["DataNasc"].ToString())
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;
        }
    }
}
