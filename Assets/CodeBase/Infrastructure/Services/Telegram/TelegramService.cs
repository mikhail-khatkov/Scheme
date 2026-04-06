using System.Runtime.InteropServices;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Telegram
{
    public class TelegramService : ITelegramService
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void TelegramShareUrl(string url, string text);
#endif

        public void ShareUrl(string url, string text)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            TelegramShareUrl(url, text);
#else
            Debug.Log($"[TelegramService] ShareUrl: {url} — {text}");
#endif
        }
    }
}
