using AutoMapper;
using LibDDD.Application.Interface;
using LibDDD.Domain.Entities;

using LibDDD.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibDDD.MVC.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ILivroAppService _livroAppService;
        //private readonly LivroRepository _livroRepository = new LivroRepository();
        // GET: Livros

        public LivrosController(ILivroAppService livroapp)
        {
            _livroAppService = livroapp;
        }
        public ActionResult Index()
        {
            var livroViewModel = Mapper.Map<IEnumerable<Livro>, IEnumerable<LivroViewModel>>(_livroAppService.GetAllWithWhere(x=> x.Ativo).OrderBy(x=> x.Descricao).ToList());
            return View(livroViewModel);
        }

        // GET: Livros/Details/5
        public ActionResult Details(int id)
        {
            var livro = _livroAppService.GetById(id);
            var livroViewModel = Mapper.Map<Livro, LivroViewModel>(livro);

            return View(livroViewModel);
        }

        // GET: Livros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LivroViewModel livro)
        {
            if (ModelState.IsValid)
            {
                var livroDomain = Mapper.Map<LivroViewModel, Livro>(livro);
                _livroAppService.Add(livroDomain);
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // GET: Livros/Edit/5
        public ActionResult Edit(int id)
        {
            var livro = _livroAppService.GetById(id);
            var livroViewModel = Mapper.Map<Livro, LivroViewModel>(livro);

            return View(livroViewModel);
        }

        // POST: Livros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LivroViewModel livro)
        {
            if (ModelState.IsValid)
            {
                var _livroDomain = Mapper.Map<LivroViewModel, Livro>(livro);
                _livroAppService.Update(_livroDomain);
                return RedirectToAction("Index");
            }
            return View(livro);
        }

        // GET: Livros/Delete/5
        public ActionResult Delete(int id)
        {
            var livro = _livroAppService.GetById(id);
            var livroViewModel = Mapper.Map<Livro, LivroViewModel>(livro);
            return View(livroViewModel);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LivroViewModel livro)
        {
            if (ModelState.IsValid)
            {
                var _livroDomain = Mapper.Map<LivroViewModel, Livro>(livro);
                _livroDomain.Ativo = false;
                _livroAppService.Update(_livroDomain);
                return RedirectToAction("Index");
            }
            return View(livro);
        }
    }
}
