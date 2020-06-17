using AutoMapper;
using Newtonsoft.Json;
using SEC.BLL.Intefaces;
using SEC.ENTITI;
using SEC.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SEC.MVC.Controllers
{
    public class PreguntasController : Controller
    {
        private readonly IPreguntasService<Preguntas> service;
        private readonly ITecnologiasService<Tecnologias> serviceTecnologias;
        private readonly IMapper Mapper;
        private readonly PreguntasporTecnologiaV2_Result v2_Result;
        public PreguntasController(IPreguntasService<Preguntas> service, ITecnologiasService<Tecnologias> serviceTecnologias, IMapper mapper,PreguntasporTecnologiaV2_Result v2_Result)
        {
            this.service = service;
            this.serviceTecnologias = serviceTecnologias;
            this.Mapper = mapper;
            this.v2_Result = v2_Result;
        }
        // GET: Usuarios
        public ActionResult Index()
        {
            ViewData["Titulo"] = "Preguntas";
            ViewData["Entity"] = "Preguntas";
            ViewData["Controller"] = "Preguntas";


            return View();
        }

        public async Task<JsonResult> ListAsync()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            string start = (Request.Form["start"].FirstOrDefault()).ToString();
            int length = Request.Form["length"].FirstOrDefault();
            string sortColumn = (Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault()).ToString();
            string sortColumnDirection = (Request.Form["order[0][dir]"].FirstOrDefault()).ToString();
            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var dat = await service.List();
            var dataQ = dat.AsQueryable();

            if (!string.IsNullOrEmpty(searchValue.ToString()) && searchValue.ToString().Length > 2)
            {
                dataQ = dataQ.Where(m => m.NombrePregunta.IndexOf(searchValue.ToString(), StringComparison.OrdinalIgnoreCase) >= 0);
            }

            recordsTotal = dataQ.Count();
            var data = dataQ.Skip(skip).Take(pageSize).ToList();

            return Json(new
            {
                draw,
                recordsFiltered = recordsTotal,
                recordsTotal,
                data
            }, JsonRequestBehavior.AllowGet);

        }

        public async Task<PartialViewResult> AddEditAsync(int itemId)
        {
            var model = new Preguntas();
            var reg = new PreguntasModel();
            reg.Opciones = new List<Opciones>();
            try
            {
                var lis = await serviceTecnologias.List();
                var datos = lis.AsQueryable();

                ViewBag.Tecnologias = datos;


                if (itemId > 0)
                {
                    model = await service.SearchById(itemId);
                    reg = Mapper.Map<Preguntas, PreguntasModel>(model);
                }
            }
            catch
            {
                throw;
            }


            return PartialView("_AddEdit", reg);
        }
        public async Task<JsonResult> SaveAsync(PreguntasModel model)
        {
            var reg = Mapper.Map<PreguntasModel, Preguntas>(model);
            try
            {
                    if (reg.IdPregunta == 0)
                {
                    reg = await service.Add(reg);
                }
                else
                {
                    await service.Update(reg);
                }
            }
            catch
            {
                throw;
            }

            var result = JsonConvert.SerializeObject(reg, Formatting.Indented,
                           new JsonSerializerSettings
                           {
                               ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                           });

            return Json(result, JsonRequestBehavior.AllowGet);

            
        }

      


        [HttpPost]
        public async Task<JsonResult> DeleteAsync(int id)
        {
            int deleted;
            try
            {
                await service.Delete(id);
                deleted = 1;
            }
            catch (Exception ex)
            {
                throw;
            }

            return Json(deleted);
        }
    }

    
}
