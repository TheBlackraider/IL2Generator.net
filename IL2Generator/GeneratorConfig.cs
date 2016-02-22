/*
 * Creado por SharpDevelop.
 * Usuario: Juan
 * Fecha: 20/01/2016
 * Hora: 12:16
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;


namespace IL2Generator
{
	
	public enum GenerationType
	{
		Campaign,Missions,OneMission
	}
	/// <summary>
	/// Description of GeneratorConfig.
	///</summary>
	public class GeneratorConfig
	{
		
		public GenerationType GenType {get; set;}
		public string Language {get; set;}
		public string Nation {get; set;}
		public string PlayerName {get; set;}
		
		private List<string> _availLang;
		private List<string> _availCountries;
		
		public List<string> Languages {
			get { return _availLang;}
		}
		
		public List<string> Nations {
			get { return _availCountries;}
		}
		
		public GeneratorConfig()
		{
			
		}
	}
}
