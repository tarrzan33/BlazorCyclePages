using System;
using BlazorCyclePages.Services;

namespace BlazorCyclePages.SessionStates
{
    public class TimerState : ITimerState
    {
        private ITimerService Timer;
        public TimerState(ITimerService timer)
        {
            Timer = timer;
        }

        private double Interval = 5000;

        public event Action OnTimerUp;

        public void StartTimer(double interval)
        {
            Interval = interval;
            Timer.SetTimer(Interval);
            Timer.OnElapsed += TimerElapsedHandler;
        }

        private void TimerElapsedHandler()
        {
            OnTimerUp?.Invoke();
            RestartTimer(Interval);
        }

        public void RestartTimer(double interval)
        {
            Timer.Restart(interval);
        }
    }
}
