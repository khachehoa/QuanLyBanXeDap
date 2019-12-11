using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectur.MVC.Controllers
{
    public class NhaCungCapController : Controller
    {
        private INhaCungCapS inhaCungCapS;
        public NhaCungCapController(INhaCungCapS inhaCungCapS)
        {
            this.inhaCungCapS = inhaCungCapS;
        }
        public IActionResult Index()
        {
            return View(inhaCungCapS.GetNhaCungCaps());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NhaCungCapViewModel save)
        {
            if (ModelState.IsValid)
            {
                save.Id = 0;
                inhaCungCapS.Create(save);
                return RedirectToAction("Index");
            }
            return View(save);
        }

         [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            else
            {
                return View();
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            inhaCungCapS.remove(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            else
            {
                var nhacc = inhaCungCapS.GetNhaCungCap(Id);
                return View(nhacc);
            }
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditConfirm(NhaCungCapViewModel save)
        {
            if (ModelState.IsValid)
            {
                inhaCungCapS.Create(save);
                return RedirectToAction("Index");
            }
            return View(save);
        }
        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            else
            {
               
                return View(inhaCungCapS.GetNhaCungCap(Id));
            }
        }
    }
}