using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MyFirstWebApiSiteG.Controllers
{
    public class orderController : Controller
    {

        IorderService _orderService;

        public orderController(IorderService orderService)
        {
            _orderService = orderService;
        }
        // GET: orderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: orderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: orderController/Create
        public async Task<ActionResult<Order>> AddOrder(Order order)
        {
            return await _orderService.AddOrderAsync(order);
        }

        // POST: orderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: orderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: orderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: orderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: orderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
