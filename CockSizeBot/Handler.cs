using BotFramework;
using BotFramework.Attributes;
using BotFramework.Enums;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;

namespace CockSizeBot;

public class Handler : BotEventHandler
{
    [Update(InChat.All, UpdateFlag.InlineQuery)]
    public async Task HandleQuery()
    {
        var query = RawUpdate.InlineQuery!;

        await Bot.AnswerInlineQueryAsync(query.Id, new[]
        {
            new InlineQueryResultArticle(
                Guid.NewGuid().ToString(), 
                "Your cock size", 
                new InputTextMessageContent($"My cock size is <b>{new Random().Next(3, 40)}cm</b>")
                {
                    ParseMode = ParseMode.Html
                })
        }, isPersonal: true);
    }
}