using System;

namespace BlazorCyclePages.Services
{
    public interface ITimerService
    {
        event Action OnElapsed;
        void Stop();
        void Restart(double interval);
        void SetTimer(double interval);
    }
}