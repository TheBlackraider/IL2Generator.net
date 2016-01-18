/*
 * Creado por SharpDevelop.
 * Usuario: Juan
 * Fecha: 18/01/2016
 * Hora: 8:39
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace IL2Generator
{
	/// <summary>
	/// Description of AllFacesReader.
	/// </summary>
	public class AllFacesReader
	{        
		private System.IO.StreamReader _reader;
        private Face theClass;
        IList<Face> theList;

        public string Separator { get; set; }
        public string FileName { get; set; }


        public AllFacesReader(string fileName, IList<Face> list)
        {
            FileName = fileName;
            Separator = ";";
            _reader = new System.IO.StreamReader(FileName);
            theList = list;
        }

        public void ReadAll()
        {
            string line;

            while ((line = _reader.ReadLine()) != null)
            {
                string[] fields = line.Split(Separator.ToCharArray());

                theClass = new Face();
                theClass.nat = fields[0];
                theClass.region = System.Convert.ToInt32(fields[1]);
                theClass.dir = fields[2];
                
                theList.Add(theClass);
            }
        }
	}
}
