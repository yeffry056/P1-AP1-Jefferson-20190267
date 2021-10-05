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

namespace P1_AP1_Jefferson_20190267.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cAportes.xaml
    /// </summary>
    public partial class cAportes : Window
    {
        public cAportes()
        {
            InitializeComponent();
        }

        private void BtnBuscar(object sender, RoutedEventArgs e)
        {
            var listado = new List<Aportes>();
            if(TextCriterio.Text.Trim().Length > 0)
            {
                switch(FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = AportesBLL.GetList(e => e.Nombre.ToLower().Contains(TextCriterio.Text.ToLower()));
                        break;
                    case 1:
                        listado = AportesBLL.GetList(e => e.Concepto.ToLower().Contains(TextCriterio.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = AportesBLL.GetList(c => true);
            }

            if (DatePickerDesde.SelectedDate != null)
                listado = AportesBLL.GetList(c => c.Fecha.Date >= DatePickerDesde.SelectedDate);
            if (DataPickerHasta.SelectedDate != null)
                listado = AportesBLL.GetList(c => c.Fecha.Date <= DataPickerHasta.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

            var conteo = listado.Count;
            if (conteo != 0)
                TextConteo.Text = Convert.ToString(conteo);

            var monto = listado.Sum(x => x.Monto);
            if (monto != 0)
                TextTotal.Text = Convert.ToString(monto);
            

        }
    }
}
