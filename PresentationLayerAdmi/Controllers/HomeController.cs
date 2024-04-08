using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer;
using BusinessLayer;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Globalization;
using System.Collections;

namespace PresentationLayerAdmi.Controllers
{   
    [Authorize]
    public class HomeController : Controller
    {
        private static int idUsuario { get; set; }

        //This method allow to get the user name logged in
        public static string GetLoggedInUserName(Controller controller)
        {
            string userLoggedIn = controller.User.Identity.Name;
            Users user = new BL_User().ToList().Where(u => u.Correo == userLoggedIn).FirstOrDefault();
            idUsuario = user.IdUsuario;
            return user?.Correo;
        }

        //This method allow to set the user name in the ViewBag
        public static void SetUserNameInViewBag(Controller controller)
        {
            string userName = GetLoggedInUserName(controller);
            controller.ViewBag.UserName = userName;
        }

        //This method allow to set the user name in the ViewBag and return the view
        public ActionResult Seleccion()
        {
            SetUserNameInViewBag(this);
            return View();
        }

        public ActionResult Tratamiento()
        {
            SetUserNameInViewBag(this);
            return View();
        }

        public ActionResult Labranza()
        {
            SetUserNameInViewBag(this);
            return View();
        }

        public ActionResult Siembra()
        {
            SetUserNameInViewBag(this);
            return View();
        }

        public ActionResult Cosecha()
        {
            SetUserNameInViewBag(this);
            return View();
        }
        public ActionResult Aporca()
        {
            SetUserNameInViewBag(this);
            return View();
        }
        public ActionResult Bactericidas()
        {
            SetUserNameInViewBag(this);
            return View();
        }
        public ActionResult Fungicidas()
        {
            SetUserNameInViewBag(this);
            return View();
        }

        public ActionResult Insecticidas()
        {
            SetUserNameInViewBag(this);
            return View();
        }

        public ActionResult Nematicidas()
            {
            SetUserNameInViewBag(this);
            return View();
        }
        public ActionResult Estimulador()
        {
            SetUserNameInViewBag(this);
            return View();
        }

        public ActionResult Quema()
        {
            SetUserNameInViewBag(this);
            return View();
        }
        public ActionResult CombateMalezas()
        {
            SetUserNameInViewBag(this);
            return View();
        }


        //This method allow to list the seleccion data on the seleccionDataTable
        [HttpGet] 
        public JsonResult SeleccionInfoList()
        {
            List<Seleccion> objSeleccionList = new List<Seleccion>();

            objSeleccionList = new BL_Seleccion().ToList(idUsuario);

            return Json(new { data = objSeleccionList }, JsonRequestBehavior.AllowGet);
        }

        //---Provinces dropDownList---

        //This method allow to list the province data on provinceDropDownList 
        [HttpGet]
        public JsonResult ProvinceList()
        {
            List<Province> objProvinceList = new List<Province>();

            objProvinceList = new BL_Province().ToList();

            return Json(new { data = objProvinceList }, JsonRequestBehavior.AllowGet);
        }

        //---City dropDownList---

        //This method allow to list the province data on provinceDropDownList 
        [HttpPost]
        public JsonResult CityList(int provinceID)
        {
            List<City> objCityList = new List<City>();

            objCityList = new BL_City().ToList(provinceID);

            return Json(new { data = objCityList }, JsonRequestBehavior.AllowGet);
        }

        //---District dropDownList---

        //This method allow to list the province data on provinceDropDownList 
        [HttpPost]
        public JsonResult DistrictList(int cityID)
        {
            List<District> objDistrictList = new List<District>();

            objDistrictList = new BL_District().ToList(cityID);

            return Json(new { data = objDistrictList }, JsonRequestBehavior.AllowGet);
        }

        //A method to save the selecion data
        [HttpPost]
        public JsonResult SaveSeleccionData(Seleccion objSeleccion)
        {
            object result;
            string message = string.Empty;

            objSeleccion.idUsuario = idUsuario;

            result = new BL_Seleccion().InsertSeleccionData(objSeleccion, out message);

            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }

        //This method allow to list the tratamiento data
        [HttpGet]
        public JsonResult TratamientoInfoList()
        {
            List<Tratamiento> objTratamientoList = new List<Tratamiento>();

            objTratamientoList = new BL_Tratamiento().ToList(idUsuario);

            return Json(new { data = objTratamientoList }, JsonRequestBehavior.AllowGet);
        }

        //This method allow to list the labranza data
        [HttpGet]
        public JsonResult LabranzaInfoList()
        {
            List<Labranza> objLabranzaList = new List<Labranza>();

            objLabranzaList = new BL_Labranza().ToList(idUsuario);

            return Json(new { data = objLabranzaList }, JsonRequestBehavior.AllowGet);
        }

        //This method allow to list the siembra data
        [HttpGet]
        public JsonResult SiembraInfoList()
        {
            List<Siembra> objSiembraList = new List<Siembra>();

            objSiembraList = new BL_Siembra().ToList(idUsuario);

            return Json(new { data = objSiembraList }, JsonRequestBehavior.AllowGet);
        }

        //This method allow to list the labranza data
        [HttpGet]
        public JsonResult AporcaInfoList()
        {
            List<Aporca> objAporcaList = new List<Aporca>();

            objAporcaList = new BL_Aporca().ToList(idUsuario);

            return Json(new { data = objAporcaList }, JsonRequestBehavior.AllowGet);
        }

        //This method allow to list the labranza data
        [HttpGet]
        public JsonResult BactericidasInfoList()
        {
            List<Bactericidas> objBactericidasList = new List<Bactericidas>();

            objBactericidasList = new BL_Bactericidas().ToList(idUsuario);

            return Json(new { data = objBactericidasList }, JsonRequestBehavior.AllowGet);
        }

        //This method allow to list the labranza data
        [HttpGet]
        public JsonResult FungicidasInfoList()
        {
            List<Fungicidas> objFungicidasList = new List<Fungicidas>();

            objFungicidasList = new BL_Fungicidas().ToList(idUsuario);

            return Json(new { data = objFungicidasList }, JsonRequestBehavior.AllowGet);
        }

        //This method allow to list the labranza data
        [HttpGet]
        public JsonResult InsecticidasInfoList()
        {
            List<Insecticidas> objInsecticidasList = new List<Insecticidas>();

            objInsecticidasList = new BL_Insecticidas().ToList(idUsuario);

            return Json(new { data = objInsecticidasList }, JsonRequestBehavior.AllowGet);
        }

        //This method allow to list the labranza data
        [HttpGet]
        public JsonResult NematicidasInfoList()
        {
            List<Nematicidas> objNematicidasList = new List<Nematicidas>();

            objNematicidasList = new BL_Nematicidas().ToList(idUsuario);

            return Json(new { data = objNematicidasList }, JsonRequestBehavior.AllowGet);
        }

        //This method allow to list the labranza data
        [HttpGet]
        public JsonResult EstimuladorInfoList()
        {
            List<Estimulador> objEstimuladorList = new List<Estimulador>();

            objEstimuladorList = new BL_Estimulador().ToList(idUsuario);

            return Json(new { data = objEstimuladorList }, JsonRequestBehavior.AllowGet);
        }

        //This method allow to list the labranza data
        [HttpGet]
        public JsonResult QuemaInfoList()
        {
            List<Quema> objQuemaList = new List<Quema>();

            objQuemaList = new BL_Quema().ToList(idUsuario);

            return Json(new { data = objQuemaList }, JsonRequestBehavior.AllowGet);
        }

        //This method allow to list the labranza data
        [HttpGet]
        public JsonResult CombateMalezasInfoList()
        {
            List<CombateMalezas> objCombateMalezasList = new List<CombateMalezas>();

            objCombateMalezasList = new BL_CombateMalezas().ToList(idUsuario);

            return Json(new { data = objCombateMalezasList }, JsonRequestBehavior.AllowGet);
        }

        //This method allow to list the labranza data
        [HttpGet]
        public JsonResult CosechaInfoList()
        {
            List<Cosecha> objCosechaList = new List<Cosecha>();

            objCosechaList = new BL_Cosecha().ToList(idUsuario);

            return Json(new { data = objCosechaList }, JsonRequestBehavior.AllowGet);
        }

        //A method to save labranza data
        [HttpPost]
        public JsonResult InsertarDatosLabranza(Labranza objLabranza)
        {
            object result;
            string message = string.Empty;

            objLabranza.IdUsuario = idUsuario;

            result = new BL_Labranza().InsertarDatosLabranza(objLabranza, out message);

            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }

        //A method to save Tratamiento data
        [HttpPost]
        public JsonResult InsertarDatosTratamiento(Tratamiento objTratamiento)
        {
            object result;
            string message = string.Empty;

            objTratamiento.idUsuario = idUsuario;

            result = new BL_Tratamiento().InsertarDatosTratamiento(objTratamiento, out message);

            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }

        //A method to save Siembra data
        [HttpPost]
        public JsonResult InsertarDatosSiembra(Siembra objSiembra)
        {
            object result;
            string message = string.Empty;

            objSiembra.idUsuario = idUsuario;

            result = new BL_Siembra().InsertarDatosSiembra(objSiembra, out message);

            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }

        //A method to save Cosecha data
        [HttpPost]
        public JsonResult InsertarDatosCosecha(Cosecha objCosecha)
        {
            object result;
            string message = string.Empty;

            objCosecha.idUsuario = idUsuario;

            result = new BL_Cosecha().InsertarDatosCosecha(objCosecha, out message);

            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }

        //A method to save Aporca data
        [HttpPost]
        public JsonResult InsertarDatosAporca(Aporca objAporca)
        {
            object result;
            string message = string.Empty;

            objAporca.IdUsuario = idUsuario;

            result = new BL_Aporca().InsertarDatosAporca(objAporca, out message);

            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }

        //A method to save Bactericidas data
        [HttpPost]
        public JsonResult InsertarDatosBactericidas(Bactericidas objBactericidas)
        {
            object result;
            string message = string.Empty;

            objBactericidas.idUsuario = idUsuario;

            result = new BL_Bactericidas().InsertarDatosBactericidas(objBactericidas, out message);

            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }

        //A method to save Fungicidas data
        [HttpPost]
        public JsonResult InsertarDatosFungicidas(Fungicidas objFungicidas)
        {
            object result;
            string message = string.Empty;

            objFungicidas.idUsuario = idUsuario;

            result = new BL_Fungicidas().InsertarDatosFungicidas(objFungicidas, out message);

            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }

        //A method to save Insecticidas data
        [HttpPost]
        public JsonResult InsertarDatosInsecticidas(Insecticidas objInsecticidas)
        {
            object result;
            string message = string.Empty;

            objInsecticidas.idUsuario = idUsuario;

            result = new BL_Insecticidas().InsertarDatosInsecticidas(objInsecticidas, out message);

            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }

        //A method to save Nematicidas data
        [HttpPost]
        public JsonResult InsertarDatosNematicidas(Nematicidas objNematicidas)
        {
            object result;
            string message = string.Empty;

            objNematicidas.idUsuario = idUsuario;

            result = new BL_Nematicidas().InsertarDatosNematicidas(objNematicidas, out message);

            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}