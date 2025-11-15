using appCore_T1_ejer02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appCore_T1_ejer02.Controllers
{
    public class BibliotecaController : Controller
    {
        //CREAMOS LA INSTANCIA DE BIBLIOTECA
        static Biblioteca objBiblioteca = new Biblioteca();

        // GET: BibliotecaController
        public ActionResult Index()
        {
            return View(objBiblioteca.ListaLibros.ToList());
        }

        // GET: BibliotecaController/Details/5
        public ActionResult Details(string id)
        {
            var libro = objBiblioteca.ObtenerPorIsbn(id);
            return View(libro);
        }

        // GET: BibliotecaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BibliotecaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                objBiblioteca.ListaLibros.Add(new Libro
                    { 
                        Isbn = collection["Isbn"],
                        Titulo = collection["Titulo"],
                        TipoLibro = collection["TipoLibro"]
                    });
                // Al agregar el libro retorna al listado
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BibliotecaController/Edit/5
        public ActionResult Edit(string id)
        {
            return View(objBiblioteca.ObtenerPorIsbn(id));
        }

        // POST: BibliotecaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                // Obtener libro
                var libro = objBiblioteca.ObtenerPorIsbn(id);
                // Actualizar valores del libro
                libro.Titulo = collection["Titulo"];
                libro.TipoLibro = collection["TipoLibro"];

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BibliotecaController/Delete/5
        public ActionResult Delete(string id)
        {
            var libro = objBiblioteca.ObtenerPorIsbn(id);
            return View(libro);
        }

        // POST: BibliotecaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                // OBTENER LIBRO
                var libro = objBiblioteca.ObtenerPorIsbn(id);
                // ELIMINAR LIBRO
                objBiblioteca.ListaLibros.Remove(libro);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
