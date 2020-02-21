using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace BlazorCyclePages.Services
{
    public class TimerService : ITimerService
    {
        private Timer _timer;
        public void SetTimer(double interval)
        {
            _timer = new Timer(interval);
            _timer.Elapsed += NotifyTimerElapsed;
            _timer.AutoReset = false;
            _timer.Start();
        }

        public event Action OnElapsed;

        private void NotifyTimerElapsed(object sender, ElapsedEventArgs e)
        {
            OnElapsed?.Invoke();
        }

        public void Restart(double interval)
        {
            _timer.Stop();
            _timer.Interval = interval;
            _timer.Start();
        }
    }
}
