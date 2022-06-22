using Microsoft.AspNetCore.Mvc;
using MoviesDex.Models;
using MoviesDex.Datos;

namespace MoviesDex.Controllers
{
    public class CRUDController : Controller
    {
        PeliculasDatos peliculasDatos = new PeliculasDatos();
       
        public IActionResult Listar()
        {
            var listapersonas = peliculasDatos.Listar();
            return View(listapersonas);

        }

       
        [HttpPost]
        public IActionResult Listar(string txtSearch)
        {
            List<ModelPelicula> listapersonas;

            if(txtSearch != null)
            {
            listapersonas = peliculasDatos.FiltrarPorTitulo(txtSearch);

            }
            else
            {
               listapersonas = peliculasDatos.Listar();
            }

                return View(listapersonas);

        }


        public IActionResult Agregar() //
        {
          
                return View();

        }

        [HttpPost]
        public IActionResult Agregar(ModelPelicula oPelicula) //
        {


            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = peliculasDatos.Agregar(oPelicula);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }


        }

        public IActionResult Eliminar(int id)
        {

            var oPelicula = peliculasDatos.Obtener(id);
            return View(oPelicula);
        }

        [HttpPost]
        public IActionResult Eliminar(ModelPelicula oPelicula)
        {
            var respuesta = peliculasDatos.Eliminar(oPelicula.id);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }


        public IActionResult Editar(int id)
        {
            var oPelicula = peliculasDatos.Obtener(id);

            return View(oPelicula);
        }
        [HttpPost]
        public IActionResult Editar(ModelPelicula oPelicula)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = peliculasDatos.Editar(oPelicula);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }


        }

    }
}
