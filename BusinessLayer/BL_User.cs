using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace BusinessLayer
{
    public class BL_User
    {
        private DL_User objDL_User = new DL_User();

        public List<Users> ToList()
        {
            return objDL_User.ToList();
        }

        public int InsertarUsuario(string Nombre, string PrimerApellido, string SegundoApellido, string Correo, string Clave, out string message)
        {
            //Falta validación de datos

            Clave = BL_Resources.encryptionSHA256(Clave);

            return objDL_User.InsertarUsuario(Nombre, PrimerApellido, SegundoApellido, Correo, Clave, out message);
        }

        public bool ChangePassword(int idUser, string newPassword, out string message)
        {
            return objDL_User.ChangePassword(idUser, newPassword, out message);
        }

        public bool ResetPassword(int idUser, string mail, out string message)
        {
            message = string.Empty;

            string newPassword = BL_Resources.CreatePassword();

            bool result = objDL_User.ResetPassword(idUser, BL_Resources.encryptionSHA256(newPassword), out message);

            if (result)
            {
                string subject = "Contraseña Reestablecida";
                string body = "<h3>Su contraseña fue reestablecida correctamente</h3></br><p>Su contraseña temporal es: !clave!</p>";
                body = body.Replace("!clave!", newPassword);

                bool answer = BL_Resources.SendMail(mail, subject, body);

                if (answer)
                {
                    return true;
                }
                else
                {
                    message = "Error al enviar el correo";
                    return false;
                }
            }
            else
            {
                message = "Error al reestablecer la contraseña";
                return false;
            }
        }  
    }
}
