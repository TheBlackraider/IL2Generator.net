/*
 * Creado por SharpDevelop.
 * Usuario: Juan
 * Fecha: 17/01/2016
 * Hora: 17:11
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace IL2Generator
{
	/// <summary>
	/// Description of BioList.
	/// </summary>
	public class BioList
	{
		private AllFacesContainer _faces;
		private AllFacesReader _reader;
		private AllLocationFilesContainer _locs;
		private AllLocationFilesReader _locreader;
		
		private List<Bio> _bio;
		
		public BioList()
		{
			_faces = new AllFacesContainer();
			_locs = new AllLocationFilesContainer();
			
			_bio = List<Bio>();
		}

		public void Load(string lang, string face)
		{
			_reader = new AllFacesReader("AllFaces.dat",_faces);
			_reader.ReadAll();
			
			_locreader = new AllLocationFilesReader("AllLocationsFiles.dat",_locs);
			_locreader.ReadAll();
			
			
		}		
	}
}
