using AutoMapper;
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
    public class TecnologiasController : Controller
    {
        private readonly ITecnologiasService<Tecnologias> service;
        private readonly IMapper Mapper;

        public TecnologiasController(ITecnologiasService<Tecnologias> service, IMapper mapper)
        {
            this.service = service;
            this.Mapper = mapper;
        }
        // GET: Usuarios
        public ActionResult Index()
        {
            ViewData["Titulo"] = "Tecnologias";
            ViewData["Entity"] = "Tecnologias";
            ViewData["Controller"] = "Tecnologias";


            return View();
        }

        public ActionResult Test()
        {
            ViewData["Titulo"] = "Tecnologias";
            ViewData["Entity"] = "Tecnologias";
            ViewData["Controller"] = "Tecnologias";


            return View();
        }

        public async Task<JsonResult> Cards() 
        {
           var reg = await service.List();

            return Json(reg, JsonRequestBehavior.AllowGet);
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
                dataQ = dataQ.Where(m => m.NombreTec.IndexOf(searchValue.ToString(), StringComparison.OrdinalIgnoreCase) >= 0);
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

        public async Task<JsonResult> SaveAsync(TecnologiasModel model)
        {
            var reg = Mapper.Map<TecnologiasModel, Tecnologias>(model);
            try
            {
                if (reg.IdTecnologia == 0)
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
            return Json(reg);
        }



        // GET: Usuarios/Edit/5
        public async Task<PartialViewResult> AddEditAsync(int itemId)
        {
            var model = new Tecnologias();
            var reg = new TecnologiasModel();
            var er = "";
            try
            {
                if (itemId > 0)
                {

                    model = await service.SearchById(itemId);
                    reg = Mapper.Map<Tecnologias, TecnologiasModel>(model);
                }
            }
            catch (Exception ex)
            {
                er = ex.Message;
                throw;
            }
            return PartialView("_AddEdit", reg);
        }



        // POST: Usuarios/Delete/5
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

