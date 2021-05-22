using ProyectoFinalPG2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Globalization;

namespace ProyectoFinalPG2
{
    /// <summary>
    /// Interaction logic for MenuLista.xaml
    /// </summary>
    public partial class MenuLista : Page
    {
        public MenuLista()
        {
            InitializeComponent();
            Refresh();
        }
        //Actualizar mi vista GridView
        private void Refresh()
        {
            List<VideoGameViewModel> list = new List<VideoGameViewModel>();
            using (Model.VideoGamesEntities db = new Model.VideoGamesEntities())
                {
                list = (from d in db.TB_Videogames
                        select new VideoGameViewModel
                        {
                            ID = d.VG_ID,
                            Nombre = d.VG_Nombre,
                            FechaCompra = d.VG_FechaCompra,
                            Precio = d.VG_Precio,
                            Estudio = d.VG_Estudio
                        }).ToList();
                DG.ItemsSource = list;
                }
        }
        //Nuevo => Redirecciona a Formulario
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.StaticMainFrame.Content = new Form();
        }
        //Exportar desde un CSV
        private void Button_Exportar(object sender, RoutedEventArgs e)
        {
            string fuente = @"C:\Users\antho\OneDrive\Escritorio\WPF.csv";
            CLSArchivo ar = new CLSArchivo();
            string[] Arreglo = ar.LeerArchivo(fuente);
            int NumeroLinea = 0;

            foreach(string linea in Arreglo)
            {
                String[] datos = linea.Split(';');
                using (Model.VideoGamesEntities db = new Model.VideoGamesEntities())
                {
                    if(NumeroLinea > 0 )
                    {
                        var oVG = new Model.TB_Videogames();
                        oVG.VG_Nombre = datos[0];
                        oVG.VG_FechaCompra = DateTime.ParseExact(datos[1], "MM/dd/yyy", CultureInfo.InvariantCulture);
                        oVG.VG_Precio = int.Parse(datos[2]);
                        oVG.VG_Estudio = datos[3];

                        db.TB_Videogames.Add(oVG);
                        db.SaveChanges();
                        Refresh();
                    }

                }
            }
            


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int ID = (int)((Button)sender).CommandParameter;

            using (Model.VideoGamesEntities db = new Model.VideoGamesEntities())
            {
                var oVG = db.TB_Videogames.Find(ID);
                db.TB_Videogames.Remove(oVG);
                db.SaveChanges();
            }
            Refresh();
        }

        private void Button_Editar(object sender, RoutedEventArgs e)
        {
            int ID = (int)((Button)sender).CommandParameter;

            Form pForm = new Form(ID);
            

            MainWindow.StaticMainFrame.Content = pForm;

            
            Refresh();
        }
    }
}
