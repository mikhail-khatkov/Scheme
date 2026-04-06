namespace CodeBase.Infrastructure.Services.Telegram
{
    public interface ITelegramService : IService
    {
        void ShareUrl(string url, string text);
    }
}
