using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlineTickets.Data;
using onlineTickets.Data.Services;
using onlineTickets.Models;

namespace onlineTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service
            ;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }
        //Get: Producer/details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }
        //Get: producer /create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
           // if (!ModelState.IsValid)
          //  {
            //    return View(producer);
           // }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //Get: producer /edit/id/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            // if (!ModelState.IsValid) return View(producer);

           if (id == producer.Id)
            { 
            await _service.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
            }
           return View(producer);
        }

        //Get: producer /delete/id/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost , ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index)); 
        }
    }
}
