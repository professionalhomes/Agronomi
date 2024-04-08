using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer;
using BusinessLayer;

using System.Web.Security;

namespace PresentationLayerAdmi.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registrarse()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string mail, string password)
        {
            Users objUser = new Users();
            objUser = new BL_User().ToList().Where(u => u.Correo == mail && u.Clave == BL_Resources.encryptionSHA256(password)).FirstOrDefault();

            if (objUser == null)
            {
                ViewBag.Error = "Correo o contraseña incorrecta";
                return View();
            }
            else
            {
                TempData["idUser"] = objUser.Correo; //se guarda el id de usuario en una variable temporal

                FormsAuthentication.SetAuthCookie(objUser.Correo, false);

                ViewBag.Error = null;

                return RedirectToAction("Seleccion", "Home");
            }
        }

        [HttpPost]
        public ActionResult Registrarse(string Nombre, string PrimerApellido, string SegundoApellido, string Correo, string Clave)
        {
            object result;
            string message = string.Empty;

            result = new BL_User().InsertarUsuario(Nombre, PrimerApellido, SegundoApellido, Correo, Clave, out message);

            return RedirectToAction("Login");
        }


        [HttpPost]
        public ActionResult ChangePassword(string idUser, string tmpPassword, string newPassword, string confirmPassword)
        {
            Users objUser = new Users();

            objUser = new BL_User().ToList().Where(u => u.IdUsuario == int.Parse(idUser)).FirstOrDefault();

            if (objUser.Clave != BL_Resources.encryptionSHA256(tmpPassword))
            {
                TempData["idUser"] = idUser;
                ViewData["vPass"] = "";
                ViewBag.Error = "Contraseña temporal incorrecta";
                return View();
            }
            else if (newPassword != confirmPassword)
            {
                TempData["idUser"] = idUser;
                ViewData["vPass"] = tmpPassword;
                ViewBag.Error = "Las contraseñas no coinciden";
                return View();
            }

            ViewData["vPass"] = "";

            newPassword = BL_Resources.encryptionSHA256(newPassword);

            string message = string.Empty;
            bool result = new BL_User().ChangePassword(int.Parse(idUser), newPassword, out message);
            
            if (result) return RedirectToAction("Login");
            else
            {
                TempData["idUser"] = idUser;
                ViewBag.Error = message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult ResetPassword(string mail)
        {
            Users objUser = new Users();

            objUser = new BL_User().ToList().Where(item => item.Correo == mail).FirstOrDefault();

            if (objUser == null)
            {
                ViewBag.Error = "No se encontró un usuario relacionado a el correo ingresado";
                return View();
            }
            else
            {
                string message = string.Empty;
                bool result = new BL_User().ResetPassword(objUser.IdUsuario, mail, out message);

                if (result)
                {
                    ViewBag.Error = null;
                    return RedirectToAction("ChangePassword");
                }
                else
                {
                    ViewBag.Error = message;
                    return View();
                }
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}