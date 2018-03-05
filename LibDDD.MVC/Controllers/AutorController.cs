using AutoMapper;
using LibDDD.Application.Interface;
using LibDDD.Domain.Entities;
using LibDDD.MVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LibDDD.MVC.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorAppService _autorAppService;

        public AutorController(IAutorAppService autorapp)
        {
            _autorAppService = autorapp;
        }
        // GET: Editora
        public ActionResult Index()
        {
            var autorViewModell = Mapper.Map<List<Autor>, List<AutorViewModel>>(_autorAppService.GetAll());
            return View(autorViewModell);
        }

        // GET: Autor/Details/5
        public ActionResult Details(int id)
        {
            var autor = _autorAppService.GetById(id);
            var _autorViewModel = Mapper.Map<Autor, AutorViewModel>(autor);
            return View(_autorViewModel);
        }

        // GET: Autor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AutorViewModel autor)
        {
            {
                var _autorDomain = Mapper.Map<AutorViewModel, Autor>(autor);
            if (ModelState.IsValid)
                _autorAppService.Add(_autorDomain);
                return RedirectToAction("Index");
            }
            return View(autor);
        }

        // GET: Autor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Autor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AutorViewModel autor)
        {
            if (ModelState.IsValid)
            {
                var _autorDomain = Mapper.Map<AutorViewModel, Autor>(autor);
                _autorAppService.Update(_autorDomain);
                return RedirectToAction("Index");
            }
            return View(autor);
        }

        // GET: Autor/Delete/5
        public ActionResult Delete(int id)
        {
            var autor = _autorAppService.GetById(id);
            var autorViewModel = Mapper.Map<Autor, AutorViewModel>(autor);

            return View(autorViewModel);
        }

        // POST: Autor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AutorViewModel autor)
        {
            if (ModelState.IsValid)
            {
                var _autorDomain = Mapper.Map<AutorViewModel, Autor>(autor);
                _autorAppService.Remove(_autorDomain);
                return RedirectToAction("Index");
            }
            return View(autor);
        }
    }
}
