using AutoMapper;
using LibDDD.Application.Interface;
using LibDDD.Domain.Entities;
using LibDDD.MVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LibDDD.MVC.Controllers
{
    public class EditoraController : Controller
    {
        private readonly IEditoraAppService _editoraAppService;

        public EditoraController(IEditoraAppService editorApp)
        {
            _editoraAppService = editorApp;
        }

        
        // GET: Editora
        public ActionResult Index()
        {
            var editoraViewModell = Mapper.Map<IEnumerable<Editora>, IEnumerable<EditoraViewModel>>(_editoraAppService.GetAll());
            return View(editoraViewModell);
        }

        // GET: Editora/Details/5
        public ActionResult Details(int id)
        {
            var editora = _editoraAppService.GetById(id);
            var _editoraViewModel = Mapper.Map<Editora, EditoraViewModel>(editora);
            return View(_editoraViewModel);
        }

        // GET: Editora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Editora/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EditoraViewModel editora)
        {
            if (ModelState.IsValid)
            {
                var _editora = Mapper.Map<EditoraViewModel, Editora>(editora);
                _editoraAppService.Add(_editora);
                return RedirectToAction("Index");
            }
            return View(editora);
        }

        // GET: Editora/Edit/5
        public ActionResult Edit(int id)
        {
            var editora = _editoraAppService.GetById(id);
            var editoraViewModel = Mapper.Map<Editora, EditoraViewModel>(editora);

            return View(editoraViewModel);
        }

        // POST: Editora/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditoraViewModel editora)
        {
            if (ModelState.IsValid)
            {
                var _editoraDomain = Mapper.Map<EditoraViewModel, Editora>(editora);
                _editoraAppService.Update(_editoraDomain);
                return RedirectToAction("Index");
            }
            return View(editora);
        }

        // GET: Editora/Delete/5
        public ActionResult Delete(int id)
        {
            var editora = _editoraAppService.GetById(id);
            var editoraViewModel = Mapper.Map<Editora, EditoraViewModel>(editora);

            return View(editoraViewModel);
        }

        // POST: Editora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EditoraViewModel editora)
        {
            if (ModelState.IsValid)
            {
                var _editoraDomain = Mapper.Map<EditoraViewModel, Editora>(editora);
                _editoraAppService.Remove(_editoraDomain);
                return RedirectToAction("Index");
            }
            return View(editora);
        }
    }
}
