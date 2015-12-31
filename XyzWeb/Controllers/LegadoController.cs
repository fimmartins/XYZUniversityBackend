using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XyzWeb.Models;

namespace XyzWeb.Controllers
{
	public class LegadoController : Controller
	{
		// GET: Legado
		public ActionResult Index()
		{
			Legado.LegadoClient l = new Legado.LegadoClient();
			LegadoModel m = new LegadoModel();

			m.NomeUniversidade = l.NomeUniversidade();
			m.Componentes = l.BuscarComponentes();
			
			return View(m);
		}
	}
}