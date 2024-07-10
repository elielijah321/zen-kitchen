using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;

namespace Project.Function
{
    public static class TelegramService
    {
      // private static readonly string APIToken = Environment.GetEnvironmentVariable("AREMU_SOFTWARE_SOLUTIONS_API_KEY");
      // private static readonly string  ChatID = Environment.GetEnvironmentVariable("AREMU_SOFTWARE_SOLUTIONS_CHAT_ID");

      private static readonly string _APIToken = "1386284989:AAGxsUk9C3AG6hP3S4kooSxZCqEIUIT8DM0";
      private static readonly string  _ChatID = "554287296";

      public static async Task<JsonResult> SendMessage(string message)
      {
        TelegramBotClient _botClient = new TelegramBotClient(_APIToken);

        var result = await _botClient.SendTextMessageAsync(_ChatID, message);

        return new JsonResult(result);
      }
    }
}