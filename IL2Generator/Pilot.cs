/*
 * Creado por SharpDevelop.
 * Usuario: Juan
 * Fecha: 17/01/2016
 * Hora: 16:06
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace IL2Generator
{
	/// <summary>
	/// Description of Pilot.
	/// </summary>
	public class Pilot
	{
		private List<string> _recs;
		
		public string firstName {get; set;}
    	public string lastName {get; set;}
    	public string birthPlace {get; set;}
    	public string photo {get; set;}
    	public string birthDate {get; set;}
    	
    	public List<string> recs
    	{
    		get { return _recs;}
    		set { _recs = value;}
    	}
    	
    	public int numRec {get; set;}
    	public bool FighterCareer {get; set;}
    	public int medals {get; set;}
    	public int rank {get; set;}
    	public int sorties {get; set;}
    	public int kills {get; set;}
    	public int ground {get; set;}
    	public int vacant {get; set;}
    	public int wounded {get; set;}
    	public Factions faction {get; set;}

		public Pilot()
		{
			_recs = new List<string>();
		}
	}
}
