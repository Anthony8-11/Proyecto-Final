using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ProyectoFinalPG2
{
    /// <summary>
    /// Interaction logic for Form.xaml
    /// </summary>
    public partial class Form : Page
    {
        public int ID { get; set; }
        public Form(int ID = 0)
        {
            InitializeComponent();
            this.ID = ID;
            if (this.ID != 0)
            {
                using (Model.VideoGamesEntities db = new Model.VideoGamesEntities())
                {
                    var oVG = db.TB_Videogames.Find(this.ID);

                    oVG.VG_Nombre = txtNombre.Text;
                    oVG.VG_FechaCompra = DateTime.Parse(txtFecha.Text);
                    oVG.VG_Precio = int.Parse(txtPrecio.Text);
                    oVG.VG_Estudio = txtEstudio.Text;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ID <= 0)
            {
                using (Model.VideoGamesEntities db = new Model.VideoGamesEntities())
                {
                    var oVG = new Model.TB_Videogames();
                    oVG.VG_Nombre = txtNombre.Text;
                    oVG.VG_FechaCompra = DateTime.Parse(txtFecha.Text);
                    oVG.VG_Precio = int.Parse(txtPrecio.Text);
                    oVG.VG_Estudio = txtEstudio.Text;

                    db.TB_Videogames.Add(oVG);
                    db.SaveChanges();

                    MainWindow.StaticMainFrame.Content = new MenuLista();
                }
            }
            else
            {
                using(Model.VideoGamesEntities db = new Model.VideoGamesEntities())
                {
                    var oVG = db.TB_Videogames.Find(ID);
                    oVG.VG_Nombre = txtNombre.Text;
                    oVG.VG_FechaCompra = DateTime.Parse(txtFecha.Text);
                    oVG.VG_Precio = int.Parse(txtPrecio.Text);
                    oVG.VG_Estudio = txtEstudio.Text;

                    db.Entry(oVG).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    MainWindow.StaticMainFrame.Content = new MenuLista();
                }
            }
        }
    }
}
