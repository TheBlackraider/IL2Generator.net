/*
 * Creado por SharpDevelop.
 * Usuario: Juan
 * Fecha: 22/02/2016
 * Hora: 8:49
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace IL2Generator
{
	/// <summary>
	/// Description of PlacesReader.
	/// </summary>
	public class PlacesReader
	{
		private System.IO.StreamReader _reader;
        private Place theClass;
        IList<AllClasses> theList;

        public string Separator { get; set; }
        public string FileName { get; set; }

        public void ReadAll()
        {
            string line;

            while ((line = _reader.ReadLine()) != null)
            {
                string[] fields = line.Split(Separator.ToCharArray());

                theClass = new Place();
                theClass.region = System.Convert.ToInt32(fields[0]);
                theClass.size = System.Convert.ToInt32(fields[1]);
                theClass.town = getData(fields);
                theList.Add(theClass);
            }
       

		}

        private string getData(Array fd)
        {
        	string d = "";
        	
        	for (int i = 2;i < fd.GetUpperBound;i++)
        	{
        		d += Trim(fd[i]);
        	}
        	
        	return d;
        }

        public PlacesReader(string fileName, IList<Place> list)
		{
            FileName = fileName;
            Separator = ";";
            _reader = new System.IO.StreamReader(FileName);
            theList = list;
			
		}
	}
}
