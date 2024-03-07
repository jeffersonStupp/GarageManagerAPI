using GarageManager.Data.Repositorio.Formatadores;
using GarageManager.Database.Contexto;
using GarageManager.Models;

namespace GarageManager.Database.Repositorio
{
    public class UsuarioRepositorio
    {
        public Usuario Adicionar(Usuario usuario)
        {
            using (var bancoDeDados = new GarageManagerContext())
            {
                usuario.NomeUsuario = Formatador.RemoverCaracteres(usuario.NomeUsuario);
                usuario.NomeUsuario = Formatador.TitleCase(usuario.NomeUsuario);
                bancoDeDados.USUARIOS.Add(usuario);
                bancoDeDados.SaveChanges();
                return usuario;
            }
        }

        public Usuario Atualizar(Usuario usuario)
        {
            using (var bancoDeDados = new GarageManagerContext())
            {
                usuario.NomeUsuario = Formatador.RemoverCaracteres(usuario.NomeUsuario);
                usuario.NomeUsuario = Formatador.TitleCase(usuario.NomeUsuario);
                bancoDeDados.USUARIOS.Update(usuario);
                bancoDeDados.SaveChanges();
                return usuario;
            }
        }

        public void Excluir(int id)
        {
            using (var bancoDeDados = new GarageManagerContext())
            {
                var usuario = bancoDeDados.USUARIOS.Where(u => u.Id == id).FirstOrDefault();

                if (usuario != null)
                {
                    bancoDeDados.Remove(usuario);
                    bancoDeDados.SaveChanges();
                }
            }
        }

        public Usuario ObterPorId(int id)
        {
            using (var bancoDeDados = new GarageManagerContext())
            {
                var usuario = bancoDeDados.USUARIOS.Where(u => u.Id == id).FirstOrDefault();

                return usuario;
            }
        }

        public List<Usuario> ObterTodos()
        {
            using (var bancoDeDados = new GarageManagerContext())
            {
                var listaUsuarios = bancoDeDados.USUARIOS.ToList();

                return listaUsuarios;
            }
        }

        public bool ExiteUsuario(string email)
        {
            using (var bancoDeDados = new GarageManagerContext())
            {
                var usuario = bancoDeDados.USUARIOS.Where(u => u.Email.ToLower() == email.ToLower()).FirstOrDefault();
                return usuario != null;
            }
        }

        public Usuario ObterPorNomeOuEmail(string nomeUsuarioOuEmail)
        {
            using (var bancoDeDados = new GarageManagerContext())
            {
                var usuario = bancoDeDados.USUARIOS.Where(u => u.NomeUsuario == nomeUsuarioOuEmail
                                                                     || u.Email == nomeUsuarioOuEmail).FirstOrDefault();
                return usuario;
            }
        }
    }
}
