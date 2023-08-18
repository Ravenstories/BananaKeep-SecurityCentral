
namespace BananaKeep_SecurityCentral.TimerFeatures
{
    public class TimerManager
    {
        private Timer timer;
        private AutoResetEvent resetEvent;
        private Action action;
        public DateTime StartedTime;
        public bool IsTimerStarted;

        public void SetTimer(Action _action)
        {
            this.action = _action;
            resetEvent = new AutoResetEvent(false);
            timer = new Timer(Execute, resetEvent, 1000, 2000);
            StartedTime = DateTime.Now;
            IsTimerStarted = true;
        }

        public void Execute(object stateInfo)
        {
            action();
            if ((DateTime.Now - StartedTime).TotalSeconds > 60)
            {
                IsTimerStarted = false;
                timer.Dispose();
            }
        }

    }
}
