/*
 * Creado por SharpDevelop.
 * Usuario: Juan
 * Fecha: 18/01/2016
 * Hora: 12:22
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;


namespace IL2Generator
{
	/// <summary>
	/// Description of AllLocationFilesReader.
	/// </summary>
	public class AllLocationFilesReader
	{
        private System.IO.StreamReader _reader;
        private LocationFile theClass;
        IList<LocationFile> theList;

        public string Separator { get; set; }
        public string FileName { get; set; }


        public AllLocationFilesReader(string fileName, IList<LocationFile> list)
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

            	theClass = new LocationFile();
            	theClass.Nation = fields[0];
            	theClass.Language = fields[1];
            	theClass.DatFile = fields[2];
            	theClass.Fallback = fields[3];
            	                             

                theList.Add(theClass);
            }
        }
	}
}
