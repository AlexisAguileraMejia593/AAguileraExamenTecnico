using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class DiscoController : Controller
    {
        // GET: Disco
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Disco disco = new ML.Disco();
            ML.Result result = BL.Disco.GetAll();
            disco.Discos = result.Objects;
            return View(disco);
        }
        [HttpGet]
        public ActionResult Form(int? IdDisco)
        {
            ML.Disco disco = new ML.Disco();
            if(IdDisco != null)
            {
                ML.Result result = BL.Disco.GetById(IdDisco.Value);
                if (result.Correct)
                {
                    //UNBOXING
                    disco = (ML.Disco)result.Object;
                }
            }
            else
            {

            }
            return View(disco);
        }
        [HttpPost]
        public ActionResult Form(ML.Disco disco)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["Imagen"];
                if (file.ContentLength > 0)
                {
                    disco.Imagen = ConvertirABase64(file);
                }
                if (disco.IdDisco == 0) //ADD
                {
                    ML.Result result = BL.Disco.Add(disco);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Se ha completado el registro";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error" + result.ErrorMessage;

                    }
                }
                else //UPDATE
                {
                    ML.Result result = BL.Disco.Update(disco);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Se ha completado la actualizacion";

                    }
                    else
                    {
                        ViewBag.Mensaje = "Error" + result.ErrorMessage;
                    }
                }
            }
            else
            {

            }
            return PartialView("Modal");
        }
        public ActionResult Delete(int IdDisco)
        {
            ML.Disco disco = new ML.Disco();
            ML.Result result = BL.Disco.Delete(IdDisco);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Se ha eliminado exitosamente!!!";
            }
            else
            {
                ViewBag.Mensaje = "Error" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }

        public string ConvertirABase64(HttpPostedFileBase Foto)
        {
            //
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            string imagen = Convert.ToBase64String(data);
            return imagen;
        }
    }
}