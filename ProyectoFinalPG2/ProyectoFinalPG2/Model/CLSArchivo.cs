using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalPG2.Model
{
    class CLSArchivo
    {
        public string[] LeerArchivo(string archivo)
        {
            String[] lineas = File.ReadAllLines(archivo);
            return lineas;
        }

        public string LeerTodoArchivos(string archivo)
        {
            string ContenidoArchivo;
            using (StreamReader reader = new StreamReader(archivo))
            {
                ContenidoArchivo = reader.ReadToEnd();
            }
            return ContenidoArchivo;
        }

        public void grabarArchivoNuevo(String archivo, String contenido)
        {
            File.WriteAllText(archivo, contenido);
        }

        public void agregarDatosArchivo(String archivo, String contenido)
        {
            using (StreamWriter sw = File.AppendText(archivo))
            {
                sw.WriteLine(contenido);
            }
        }
    }
}
