using System;
using System.Windows;

namespace CronometroAncert
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cronometro _cronometro;

        public MainWindow()
        {
            InitializeComponent();

            _cronometro = new Cronometro();
            _cronometro.MarcarTiempo += ActualizarTiempo;
        }

        public void ActualizarTiempo(object sender, TimeSpan timeSpan)
        {
            HorasMinutosSegundosFormatoDigital horasMinutosSegundosFormatoDigital = new HorasMinutosSegundosFormatoDigital(timeSpan);
            LbHoras.Content = horasMinutosSegundosFormatoDigital.Horas;
            LbMinutos.Content = horasMinutosSegundosFormatoDigital.Minutos;
            LbSegundos.Content = horasMinutosSegundosFormatoDigital.Segundos;
        }

        #region Botones
        private void BtStart_Click(object sender, RoutedEventArgs e)
        {
            _cronometro.Start();
        }

        private void BtPause_Click(object sender, RoutedEventArgs e)
        {
            _cronometro.Pause();
        }

        private void BtStop_Click(object sender, RoutedEventArgs e)
        {
            _cronometro.Stop();
        }
        #endregion
    }
}
