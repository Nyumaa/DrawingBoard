using DrawingBoard.Data;
using DrawingBoard.Data.Repository;
using DrawingBoard.Models;
using DrawingBoard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DrawingBoard.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;

        public HomeController( IRepository repo)
        {
            _repo = repo;
        }
        [HttpPost] 
        public async Task<IActionResult> Draw(string draw)
        {
            _repo.AddDraw(new Draw { value = draw });
            await _repo.SaveChangesAsync();
            return View("Index");
        } 
        [HttpPost]
        public async Task<IActionResult> Delete(string draw)
        {
            _repo.RemoveDraw(draw);
            await _repo.SaveChangesAsync();
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(string old, string newPath)
        {
            Draw drawPath = _repo.GetDraw(old);
            drawPath.value = newPath;
            _repo.UpdateDraw(drawPath);
            await _repo.SaveChangesAsync();
            return View("Index");
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
