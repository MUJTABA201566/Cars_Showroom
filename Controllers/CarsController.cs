using Cars_Showroom.Data;
using Cars_Showroom.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars_Showroom.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.cars./*Where(i => i.Availability == true).*/ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Car car)
        {

            if (ModelState.IsValid)
            {
                _context.cars.Add(car);
                _context.SaveChanges();
                return RedirectToAction("Index");                
            }
            {
                return View(car);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var carFromDb = _context.cars.FirstOrDefault(i => i.Id == id);
            if(carFromDb == null)
            {
                return NotFound();
            }
            return View(carFromDb);
        }

        [HttpPost]
        public IActionResult Update(Car car)
        {
            if (ModelState.IsValid)
            {
                _context.cars.Update(car);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(car);
            }
        }
        public IActionResult Delete(int Id)
        {
            var carFromDb = _context.cars.Find(Id);
            if (carFromDb == null)
            {
                return RedirectToAction("Index");
            }
            _context.cars.Remove(carFromDb);
            _context.SaveChanges(true);
            return RedirectToAction("Index");
        }

        public IActionResult Soft_Delete(int Id)
        {
            var carFromDb = _context.cars.Find(Id);
            if (carFromDb == null)
            {
                return RedirectToAction("Index");
            }
            carFromDb.Availability = false;
            _context.SaveChanges(true);
            return RedirectToAction("Index");
        }
    }
}
