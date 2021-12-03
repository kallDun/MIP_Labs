using System.Threading.Tasks;

namespace Lab_2
{
    public enum State
    {
        В, П, Д, СС, None
    }

    class TrafficLight
    {
        private const int delay = 1000; // 1s
        private bool timer_street_changer_working, timer_cross_over_working;
        private State state, street;

        public delegate void OnChangeState(State state);
        public event OnChangeState ChangeState;

        public void Start() => ChangeStreetTimerStart();
        public void Stop()
        {
            timer_street_changer_working = false;
            timer_cross_over_working = false;
        }

        private async void ChangeStreetTimerStart()
        {
            timer_street_changer_working = true;
            while (timer_street_changer_working)
            {
                ChangeStreet();
                await Task.Delay(delay);
            }
        }
        private void ChangeStreet()
        {
            street = street switch
            {
                State.В => State.П,
                State.П => State.В,
                _ => State.В
            };
            state = street;
            ChangeState?.Invoke(state);
        }

        public void AllowCrossOver()
        {
            timer_street_changer_working = false;
            CrossOverTimerStart();
        }
        private async void CrossOverTimerStart()
        {
            timer_cross_over_working = true;
            while (timer_cross_over_working)
            {
                CrossOver();
                await Task.Delay(delay);
            }
        }
        private void CrossOver()
        {
            state = state switch
            {
                State.Д => State.СС,
                State.СС => State.None,
                _ => State.Д
            };
            if (state is State.None)
            {
                timer_cross_over_working = false;
                ChangeStreetTimerStart();
            }
            else
            {
                ChangeState?.Invoke(state);
            }
        }
    }
}
