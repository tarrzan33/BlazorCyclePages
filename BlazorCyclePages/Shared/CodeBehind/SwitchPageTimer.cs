using BlazorCyclePages.SessionStates;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorCyclePages.Shared.CodeBehind
{
    public class SwitchPageTimer : ComponentBase, IDisposable
    {
        
        private string NextPage;
        private double Interval;
        [Inject]
        ITimerState TimerState { get; set; }
        [Inject]
        NavigationManager NavManager { get; set; }
        public void SetNextPage(string nextPage) => NextPage = nextPage;
        public void SetInterval(double interval) => Interval = interval;

        protected override void OnAfterRender(bool firstRender)
        {
            TimerState.StartTimer(Interval);
            TimerState.OnTimerUp += TimerUp;
        }

        private void TimerUp()
        {
            TimerState.OnTimerUp -= TimerUp;
            NavManager.NavigateTo(NextPage ?? "/");
        }

        public void Dispose()
        {
            TimerState.OnTimerUp -= TimerUp;
            TimerState.Stop();
        }

    }
}
