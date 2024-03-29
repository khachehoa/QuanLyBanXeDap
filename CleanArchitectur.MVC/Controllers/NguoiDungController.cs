﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectur.MVC.Controllers
{
    
    public class NguoiDungController : Controller
    {
        private INguoiDungService iNguoiDungService;

        public NguoiDungController(INguoiDungService iNguoiDungService)
        {
            this.iNguoiDungService = iNguoiDungService;
        }

        public IActionResult Index()
        {
            return View(iNguoiDungService.GetNguoiDungs());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NguoiDungViewModel save)
        {
            if (ModelState.IsValid)
            {
                save.Id = 0;
                iNguoiDungService.Create(save);
                return RedirectToAction("Index");
            }
            return View(save);
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
                var nguoi = iNguoiDungService.GetNguoiDung(Id);
                return View(nguoi);
            }
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
            iNguoiDungService.remove(Id);
            return RedirectToAction("Index");
        }
    }
}