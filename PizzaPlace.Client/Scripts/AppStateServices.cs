using Blazored.SessionStorage;
namespace PizzaPlace.Client.Scripts
{
    public class AppStateService
    {
        private readonly ISessionStorageService _sessionStorage;
        private const string Key = "MySessionData";

        public AppStateService(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        // A private field to hold the in-memory state
        private MySessionData _state;

        // A public method to retrieve the state
        public async Task<MySessionData> GetStateAsync()
        {
            if (_state == null)
            {
                // Load state from session storage on first access
                _state = await _sessionStorage.GetItemAsync<MySessionData>(Key) ?? new MySessionData();
            }
            return _state;
        }

        // A public method to save the state
        public async Task SaveStateAsync(MySessionData state)
        {
            _state = state;
            await _sessionStorage.SetItemAsync(Key, _state);
        }
    }

    // Data/MySessionData.cs
    public class MySessionData
    {
        public string Name { get; set; } = "BeetleJuice";
        public string Email { get; set; } = "bj@yahoo.com";
        public string Size { get; set; } = "Small";
        public IEnumerable<string> SelectedToppings = new List<string> { };
        public string CrustType { get; set; } = "You betcha!";
        public float tip { get; set; } = 0;
        public float Total { get; set; } = 0;
    }
}