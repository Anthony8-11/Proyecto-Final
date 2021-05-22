
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalPG2.Model
{
    public class VideoGameViewModel
    {
           public int ID { get; set; }
           public string Nombre { get; set; }
           public DateTime FechaCompra { get; set; }
           public int Precio { get; set; }
           public string Estudio { get; set; }

    }
}
