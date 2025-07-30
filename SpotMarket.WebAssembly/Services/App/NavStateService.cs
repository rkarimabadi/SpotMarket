namespace SpotMarket.WebAssembly.Services.App
{
    public class NavStateService : IDisposable
    {

        public string? CurrentTitle { get; private set; }


        public bool ShowBackButton { get; private set; }


        public event Action? OnStateChange;


        public void SetNavState(string title, bool showBackButton)
        {
            CurrentTitle = title;
            ShowBackButton = showBackButton;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();

        public void Dispose()
        {
            if (OnStateChange != null)
            {
                foreach (var d in OnStateChange.GetInvocationList())
                {
                    OnStateChange -= (Action)d;
                }
            }
        }
    }

}
