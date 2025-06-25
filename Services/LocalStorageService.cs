using Microsoft.JSInterop;
using System.Threading.Tasks;
using System.Text.Json; // Adicione para serialização JSON

namespace PwaAppIFMS.Services
{
    public class LocalStorageService
    {
        private readonly IJSRuntime _jsRuntime;

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async ValueTask SetItemAsync<T>(string key, T value)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
        }

        public async ValueTask<T?> GetItemAsync<T>(string key)
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
            if (string.IsNullOrEmpty(json))
            {
                return default;
            }
            return JsonSerializer.Deserialize<T>(json);
        }

        public async ValueTask RemoveItemAsync(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}