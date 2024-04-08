using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    public class BL_Resources
    {
        //this method encrypts the password when a new user registers

        public static string encryptionSHA256(string text)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(text));

                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        //This method create a random password
        public static string CreatePassword()
        {
            string password = Guid.NewGuid().ToString("N").Substring(0, 8);

            return password;
        }

        //This method send the temporal password by mail to the user

        public static bool SendMail(string sender, string subject, string message)
        {
            bool result = false;

            try
            {
                MailMessage mail = new MailMessage(); //create a mail object that content the mail info
                mail.To.Add(sender);
                mail.From = new MailAddress("keilyn.jimenezbogantes@catie.ed.cr");
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;

                //A configuration to server client that send the mail
                var smtp = new SmtpClient()
                {
                    Credentials = new NetworkCredential("ljimenezbogantes@gmail.com", "gnsidxldjmidubpd"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                };

                smtp.Send(mail);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        //validaciones

        public static bool IsValidProjectCode(string projectCode)
        {
            //Example projectCode = PS-XXX-XXXX where X is a digit

            if (projectCode.Length < 11) return false;

            if (projectCode[0] != 'P') return false;

            if (projectCode[1] != 'S') return false;

            if (projectCode[2] != '-') return false;

            if (!char.IsDigit(projectCode[3])) return false;

            if (!char.IsDigit(projectCode[4])) return false;

            if (!char.IsDigit(projectCode[5])) return false;

            if (projectCode[6] != '-') return false;

            if (!char.IsDigit(projectCode[7])) return false;

            if (!char.IsDigit(projectCode[8])) return false;

            if (!char.IsDigit(projectCode[9])) return false;

            if (!char.IsDigit(projectCode[10])) return false;

            return true;
        }

        public static bool IsValidName(string name)
        {
            if (name.Length > 100) return false;

            foreach (char c in name)
            {
                if (!Char.IsLetter(c) && !Char.IsWhiteSpace(c) && !Char.IsDigit(c)) return false;
            }

            return true;
        }

        public static bool IsValidDate(string date)
        {
            try
            {
                DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool isValidCost(string cost)
        {
            foreach (char c in cost)
            {
                if (!Char.IsDigit(c) && c != ',') return false;
            }

            return true;
        }

        public static bool IsValidString(string str)
        {
            if (str.Length > 30) return false;

            foreach (char c in str)
            {
                if (!Char.IsLetter(c) && !Char.IsWhiteSpace(c)) return false;
            }

            return true;
        }

        public static bool IsValidMail(string mail)
        {
            if (mail.Length > 100)
            {
                return false;
            }

            try
            {
                var address = new System.Net.Mail.MailAddress(mail);
                return address.Address == mail;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidDNI(string dni)
        {
            Regex regex = new Regex(@"^\d{9}$");
            if (!regex.IsMatch(dni))
            {
                return false;
            }
            else
            {
                if (dni[1] == '0' && dni[6] == '0' && dni[8] == '0')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool isValidCedulaJuridica(string cedula)
        {
            Regex regex = new Regex(@"^\d{1}-\d{4}-\d{4}$");
            if (!regex.IsMatch(cedula))
            {
                return false;
            }
            else
            {
                // Eliminar el guion (-) y convertir a un arreglo de caracteres
                char[] cedulaChars = cedula.Replace("-", "").ToCharArray();

                // Validar que todos los caracteres sean dígitos numéricos
                foreach (char c in cedulaChars)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }

                // Validar el primer dígito (debe ser un número del 1 al 9)
                if (cedulaChars[0] < '1' || cedulaChars[0] > '9')
                {
                    return false;
                }

                // Validar el dígito de control
                int suma = 0;
                int multiplicador = 2;
                for (int i = cedulaChars.Length - 2; i >= 0; i--)
                {
                    int producto = int.Parse(cedulaChars[i].ToString()) * multiplicador;
                    suma += producto > 9 ? producto - 9 : producto;
                    multiplicador = multiplicador == 2 ? 1 : 2;
                }
                int digitoControl = (10 - (suma % 10)) % 10;
                return digitoControl == int.Parse(cedulaChars[cedulaChars.Length - 1].ToString());
            }
        }

        public static bool ValidarNumeroTelefonico(string numero)
        {
            Regex regex = new Regex(@"^\d{4}-\d{4}$");
            if (!regex.IsMatch(numero))
            {
                return false;
            }
            else
            {
                // Eliminar el guion (-) y convertir a un arreglo de caracteres
                char[] numeroChars = numero.Replace("-", "").ToCharArray();

                // Validar que todos los caracteres sean dígitos numéricos
                foreach (char c in numeroChars)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
