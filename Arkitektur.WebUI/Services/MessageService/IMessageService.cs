namespace Arkitektur.WebUI.Services.MessageService
{
    public interface IMessageService
    {
        public Task SendMessageAsync(string email,bool isCancelled, DateTime date);

    }
}
