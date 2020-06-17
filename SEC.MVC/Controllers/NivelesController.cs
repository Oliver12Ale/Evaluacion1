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
    public class NivelesController : Controller
    {
        private readonly INivelesService<Niveles> service;
        private readonly IMapper Mapper;

        public NivelesController(INivelesService<Niveles> service, IMapper mapper)
        {
            this.service = service;
            this.Mapper = mapper;
        }
        // GET: Usuarios
        public ActionResult Index()
        {
            ViewData["Titulo"] = "Niveles";
            ViewData["Entity"] = "Niveles";
            ViewData["Controller"] = "Niveles";


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
                dataQ = dataQ.Where(m => m.Nivel.IndexOf(searchValue.ToString(), StringComparison.OrdinalIgnoreCase) >= 0);
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


        public async Task<JsonResult> SaveAsync(NivelesModel model)
        {
            var reg = Mapper.Map<NivelesModel, Niveles>(model);
            try
            {
                if (reg.IdNivel == 0)
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
            var model = new Niveles();
            var reg = new NivelesModel();
            var er = "";
            try
            {
                if (itemId > 0)
                {

                    model = await service.SearchById(itemId);
                    reg = Mapper.Map<Niveles, NivelesModel>(model);
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
