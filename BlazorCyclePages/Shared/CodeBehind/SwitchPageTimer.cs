using BlazorCyclePages.SessionStates;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorCyclePages.Shared.CodeBehind
{
    public class SwitchPageTimer : ComponentBase
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
            Console.WriteLine("State After Render");
        }

        private void TimerUp()
        {
            Console.WriteLine("TimerUp");
            TimerState.OnTimerUp -= TimerUp;
            NavManager.NavigateTo(NextPage ?? "/");
        }

        
    }
}
