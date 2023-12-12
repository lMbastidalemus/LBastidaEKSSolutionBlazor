using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public object Object { get; set; }

        public bool Correct { get; set; }
        public static Usuario GetByIdEmail(string email, string password)
        {
            Usuario usuarioResult = new Usuario();

            try
            {
                using (DL.LBastidaEKSSolutionEntities context = new DL.LBastidaEKSSolutionEntities())
                {
                    var query = context.GetByEmail(email).SingleOrDefault();

                    if(query != null)
                    {
                        Usuario usuario = new Usuario();
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuarioResult.Object = usuario;
                        usuarioResult.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return usuarioResult;
        }

        public static Usuario Registrar(Usuario usuario)
        {
            Usuario result = new Usuario();

            try
            {
                using (DL.LBastidaEKSSolutionEntities context = new DL.LBastidaEKSSolutionEntities())
                {
                    var query = context.Registrar(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception)
            {
                result.Correct = false;
            }
            return result;
        }

    }
}
