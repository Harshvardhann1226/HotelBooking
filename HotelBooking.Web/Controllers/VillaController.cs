using HotelBooking.Domain.Entity;
using HotelBooking.Domain.ViewModel;
using HotelBooking.Repository.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        public VillaController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<IActionResult> VillaIndex()
        {
            var villa = await _unitofWork.Repository<Villa>().GetAllAsync();
            return View(villa);
        }
        public IActionResult CreateVilla()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateVilla([FromBody] VillaVM villaVm)
        {
            Villa create = new Villa()
            {
                Name = villaVm.Name,
                Price = villaVm.Price,
                Sqft = villaVm.Sqft,
                Description = villaVm.Description,
                Occupency = villaVm.Occupency,
                CretedDate = DateTime.UtcNow
            };
            await _unitofWork.Repository<Villa>().InsertAsync(create);
            await _unitofWork.SaveAsync();
            return Json(new { Success = true });

            //return RedirectToAction("VillaIndex");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateVilla(int id)
        {
            var villa = await _unitofWork.Repository<Villa>().GetById(id);
            if (villa == null) return NotFound();

            // Map entity to view model
            VillaVM vm = new VillaVM
            {
                Id = villa.Id,
                Name = villa.Name,
                Description = villa.Description,
                Price = villa.Price,
                Sqft = villa.Sqft,
                Occupency = villa.Occupency,
                ImageUrl = villa.ImageUrl
            };
            return Json(new { Success = true, data = vm });
            // ✅ Must pass VillaVM to the partial view
            //return PartialView("_EditVillaPartial", vm);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            await _unitofWork.Repository<Villa>().DeleteAsync(id);
            await _unitofWork.SaveAsync();

            return Json(new { Success = true });
        }
    }
}
