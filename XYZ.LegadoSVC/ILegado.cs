using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace XYZ.LegadoSVC
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface ILegado
	{

		[OperationContract]
		Componentes BuscarComponentes();
	}


	// Use a data contract as illustrated in the sample below to add composite types to service operations.
	[DataContract]
	public class Componentes
	{
		private List<string> _nomes;
		private string _curso;
		private string _materia;

		public Componentes(string curso, string materia)
		{
			this._nomes = new List<string>();
			this._curso = curso;
			this._materia = materia;
		}

		[DataMember]
		public string Curso
		{
			get { return this._curso; }
		}

		[DataMember]
		public string Materia
		{
			get { return this._materia; }
		}

		[DataMember]
		public string[] Nomes
		{
			get { return this._nomes.ToArray(); }
		}

		public void AddNomes(string nome)
		{
			this._nomes.Add(nome);
		}
	}
}
