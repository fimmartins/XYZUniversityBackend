using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace XYZ.LegadoSVC
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class Legado : ILegado
	{
		public Componentes BuscarComponentes()
		{
			Componentes c = new Componentes("ASD - Arquitetura de Software Distribuido", "ASW - Arquitetura de Software Web");

			c.AddNomes("Felipe Tercio");
			c.AddNomes("Frederico Martins");
			c.AddNomes("Pedro Golino");

			return c;
		}
	}
}
