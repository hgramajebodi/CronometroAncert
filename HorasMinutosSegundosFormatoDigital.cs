using System;

namespace CronometroAncert
{
    public class HorasMinutosSegundosFormatoDigital
    {
        private TimeSpan _dateTime;

        public string Horas { get { return _dateTime.Hours.ToString("00"); } }
        public string Minutos { get { return _dateTime.Minutes.ToString("00"); } }
        public string Segundos { get { return _dateTime.Seconds.ToString("00"); } }

        public HorasMinutosSegundosFormatoDigital(TimeSpan dateTime)
        {
            _dateTime = dateTime;
        }
    }
}
