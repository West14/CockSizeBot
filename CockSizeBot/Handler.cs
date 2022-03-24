using BotFramework;
using BotFramework.Attributes;
using BotFramework.Enums;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;

namespace CockSizeBot;

public class Handler : BotEventHandler
{

    private string[] emojies = { "🥱", "😛", "😎", "😱", "🤥" }; // emoji list

    [Update(InChat.All, UpdateFlag.InlineQuery)]
    public async Task HandleQuery()
    {
        var query = RawUpdate.InlineQuery!;

        int random = new Random().Next(3, 40);
        int index = random / 8; // шаг емодзи - 8 см

        await Bot.AnswerInlineQueryAsync(query.Id, new[]
        {
            new InlineQueryResultArticle(
                Guid.NewGuid().ToString(), 
                "Your cock size", 
                new InputTextMessageContent($"My cock size is <b>{random}cm{emojies[index]}</b>")
                {
                    ParseMode = ParseMode.Html
                })
        }, isPersonal: true);
    }
}