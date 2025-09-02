namespace SpotMarket.Shared.Services.App
{
    public class NavStateService : IDisposable
    {

        public string? CurrentTitle { get; private set; }


        public bool ShowBackButton { get; private set; }
        public string BackUrl { get; private set; } = "/";


        public event Action? OnStateChange;


        public void SetNavState(string title, bool showBackButton, string backUrl = "/")
        {
            CurrentTitle = title;
            ShowBackButton = showBackButton;
            BackUrl = backUrl;
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
