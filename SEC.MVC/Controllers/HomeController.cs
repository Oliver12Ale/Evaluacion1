using AutoMapper;
using Sec.Bll.Interfaces;
using Sec.Bll.Servicios;
using SEC.ENTITI;
using SEC.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SEC.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUsuariosService<Usuarios> service;
        private readonly IMapper mapper;

        public HomeController( IUsuariosService<Usuarios> service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;        
                
        }

        public ActionResult Index()
        {

            return View();


        }

        [HttpGet]
        public ActionResult Login(string usuario, string contraseña)
        {
            

            try
            {
                
            }
            catch
            {
                throw;
            }
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

}

   
    
