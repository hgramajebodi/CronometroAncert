using System;
using System.Diagnostics;
using System.Windows.Threading;

namespace CronometroAncert
{
    internal class Cronometro
    {
        private readonly Stopwatch _stopWatch;
        private readonly DispatcherTimer _timer;

        public event EventHandler<TimeSpan> MarcarTiempo;

        /// <summary>
        /// Constructor de la clase.
        /// Necesita el Formulario que se va actualizar con el Cronómetro
        /// </summary>
        /// <param name="window"></param>
        public Cronometro() 
        {
            _stopWatch = new Stopwatch();

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += HandleTimerActualizar;
        }

        private void AMarcarTiempo(TimeSpan timeSpan)
        {
            MarcarTiempo?.Invoke(this, timeSpan);
        }

        private void HandleTimerActualizar(object sender, EventArgs e)
        {
            AMarcarTiempo(TimeSpan.FromMilliseconds(_stopWatch.ElapsedMilliseconds));
        }

        #region Métodos Públicos
        /// <summary>
        /// Actualiza el Formulario y Inicia el Cronómetro
        /// </summary>
        public void Start()
        {
            _timer.Start();
            _stopWatch.Start();
            AMarcarTiempo(TimeSpan.FromMilliseconds(_stopWatch.ElapsedMilliseconds));
        }

        /// <summary>
        /// Para el Cronómetro y lo Resetea a 0
        /// </summary>
        public void Stop()
        {
            Pause();
            _stopWatch.Reset();
            AMarcarTiempo(TimeSpan.Zero);
        }

        /// <summary>
        /// Pausa el Cronómetro
        /// </summary>
        public void Pause()
        {
            _timer.Stop();
            _stopWatch.Stop();
        }
        #endregion
    }
}
