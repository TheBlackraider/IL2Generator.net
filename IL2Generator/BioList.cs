using System;
using System.Collections.Generic;
using System.Linq;

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
		private PlacesContainer _places;
		private PlacesReader _placesreader;
		
		private string _nation;
		
		private List<Bio> _bio;
		
		public BioList(string Nation)
		{
			_faces = new AllFacesContainer();
			_locs = new AllLocationFilesContainer();
			_places = new PlacesContainer();
			
			_nation = Nation;
			
			_bio = new List<Bio>();
		}

		public void Load(string lang, string face)
		{
			_reader = new AllFacesReader("AllFaces.dat",_faces);
			_reader.ReadAll();
			
			_locreader = new AllLocationFilesReader("AllLocationsFiles.dat",_locs);
			_locreader.ReadAll();
			
			var loc = from f in _locs where _nation ==	f.Nation select f;
			
			if (loc != null)
			{
				try
				{
                    LocationFile l = loc.First();

                    _placesreader = new PlacesReader(l.DatFile,_places);
				}
				catch
				{
					try
					{
                        LocationFile l = loc.First();

                        _placesreader = new PlacesReader(l.Fallback,_places);
					}
					catch
					{
						throw new System.Exception("No hay fichero de Localizaciones");
					}
				}
						
			}
			else
			{
				throw new System.Exception("No hay fichero de Localizaciones o los parametros elegidos son incorrectos. Revise AllLocationFiles.dat");
			}
		
	
		}	
		
		
	}
}
