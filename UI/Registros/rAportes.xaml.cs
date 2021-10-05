using P1_AP1_Jefferson_20190267.BLL;
using P1_AP1_Jefferson_20190267.Entidades;
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
using System.Windows.Shapes;

namespace P1_AP1_Jefferson_20190267.UI.Registros
{
    /// <summary>
    /// Interaction logic for rAportes.xaml
    /// </summary>
    public partial class rAportes : Window
    {
        private Aportes aportes = new Aportes();
        public rAportes()
        {
            InitializeComponent();
            this.DataContext = aportes;
        }
        public void Limpiar()
        {
            aportes = new Aportes();
            this.DataContext = aportes;
        }
        private bool Validar()
        {
            bool esValido = true;
            if(TextAporteID.Text.Length == 0 || Convert.ToInt32(TextAporteID.Text) == 0)
            {
                esValido = false;
                MessageBox.Show("Aporte Id vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextNombre.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Persona vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextConcepto.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Concepto vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextMonto.Text.Length == 0 || Convert.ToInt32(TextMonto.Text) == 0)
            {
                esValido = false;
                MessageBox.Show("Monto vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            return esValido;
        }
        private bool ValidarBtnEliminar()
        {
            bool esValido = true;
            if (TextAporteID.Text.Length == 0 || Convert.ToInt32(TextAporteID.Text) == 0)
            {
                esValido = false;
                MessageBox.Show("Aporte Id vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }else if(TextNombre.Text.Length == 0 || TextConcepto.Text.Length == 0 || TextMonto.Text.Length == 0 || Convert.ToInt32(TextMonto.Text) == 0)
            {
                esValido = false;
                MessageBox.Show("Debe buscar el aporte que desea eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BtnBuscar(object sender, RoutedEventArgs e)
        {
            if (TextAporteID.Text.Length == 0 || Convert.ToInt32(TextAporteID.Text) == 0)
            {
                MessageBox.Show("Aporte Id vacio", "Existo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var aportes = AportesBLL.Buscar(Convert.ToInt32(TextAporteID.Text));
            if (aportes != null)
                this.aportes = aportes;
            else
            {
                MessageBox.Show($"No existe un aporte con este id: {Convert.ToInt32(TextAporteID.Text)}", "Existo", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
            }

            this.DataContext = this.aportes;
            
        }

        private void BtnNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BtnGuardar(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = AportesBLL.Guardar(aportes);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion Exitosa", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);
            }else
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BtnEliminar(object sender, RoutedEventArgs e)
        {
            if (!ValidarBtnEliminar())
                return;

            if (AportesBLL.Eliminar(Convert.ToInt32(TextAporteID.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado", "Existo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar el registro", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
