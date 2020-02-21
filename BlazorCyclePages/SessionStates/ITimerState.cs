using System;

namespace BlazorCyclePages.SessionStates
{
    public interface ITimerState
    {
        event Action OnTimerUp;
        void StartTimer(double interval);
        void RestartTimer(double interval);
    }
}