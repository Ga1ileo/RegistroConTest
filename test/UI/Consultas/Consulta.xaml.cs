using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using test.BLL;
using test.Entidades;

namespace test.UI.Consultas
{
    /// <summary>
    /// Interaction logic for Consulta.xaml
    /// </summary>
    public partial class Consulta : Window
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Personas>();
            if(CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = PersonasBLL.GetList(p => true);
                        break;
                    case 1:
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = PersonasBLL.GetList(p => p.PersonaID == id);
                        break;
                    case 2:
                        listado = PersonasBLL.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;
                    case 3:
                        listado = PersonasBLL.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;
                    case 4:
                        listado = PersonasBLL.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;
                }

            }
            else
            {
                listado = PersonasBLL.GetList(p => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = listado;
        }
    }
}
