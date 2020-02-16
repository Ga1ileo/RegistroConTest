using System;
using System.Collections.Generic;
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

namespace test.UI.Registros
{
    /// <summary>
    /// Interaction logic for Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            FechaDatePicker.SelectedDate = DateTime.Now;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Personas LlenaClases()
        {
            Personas persona = new Personas();
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                IdTextBox.Text = "0";
            }
            else persona.PersonaID = Convert.ToInt32(IdTextBox.Text);
            persona.Nombre = NombreTextBox.Text;
            persona.Telefono = TelefonoTextBox.Text;
            persona.Cedula = CedulaTextBox.Text;
            persona.Direccion = DireccionTextBox.Text;
            persona.FechaNacimiento = Convert.ToDateTime(FechaDatePicker.SelectedDate);
            
            return persona;
        }

        private void LlenaCampos(Personas persona)
        {
            IdTextBox.Text = Convert.ToString(persona.PersonaID);
            NombreTextBox.Text = persona.Nombre;
            TelefonoTextBox.Text = persona.Telefono;
            CedulaTextBox.Text = persona.Cedula;
            DireccionTextBox.Text = persona.Direccion;
            FechaDatePicker.SelectedDate = persona.FechaNacimiento;
        }

        private bool Validar()
        {
            bool paso = true;
            if (NombreTextBox.Text == string.Empty)
            {
                System.Windows.MessageBox.Show(NombreTextBox.Text, "No puede estar vacio");
                NombreTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                System.Windows.MessageBox.Show(DireccionTextBox.Text, "No puede estar vacio");
                DireccionTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulaTextBox.Text))
            {
                System.Windows.MessageBox.Show(CedulaTextBox.Text, "No puede estar vacio");
                CedulaTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool ExisteBD()
        {
            Personas persona = PersonasBLL.Buscar(Convert.ToInt32(IdTextBox.Text));

            return (persona != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Personas persona;
            bool paso = false;

            if (!Validar())
                return;

            persona = LlenaClases();

            if (string.IsNullOrWhiteSpace(IdTextBox.Text) || IdTextBox.Text == "0")
                paso = PersonasBLL.Guardar(persona);
            else
            {
                if (!ExisteBD())
                {
                    System.Windows.MessageBox.Show("No Se puede Modificar porque no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = PersonasBLL.Modificar(persona);
            }

            if (paso)
            {
                Limpiar();
                System.Windows.MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                System.Windows.MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(IdTextBox.Text);

            Limpiar();

            if (PersonasBLL.Eliminar(id))
                System.Windows.MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                System.Windows.MessageBox.Show(IdTextBox.Text, "No se puede eliminar una persona que no existe");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Personas persona = new Personas();
            int.TryParse(IdTextBox.Text, out id);

            Limpiar();

            persona = PersonasBLL.Buscar(id);

            if (persona != null)
            {
                System.Windows.MessageBox.Show("Persona Encontrada");
                LlenaCampos(persona);
            }
            else
            {
                System.Windows.MessageBox.Show("Persona no Encontrada");
            }
        }
    }
}
