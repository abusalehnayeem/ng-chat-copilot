using Microsoft.SemanticKernel.AI;
using Microsoft.SemanticKernel.AI.ChatCompletion;

namespace Ng.Chat.Copilot.Api.Connectors
{
    public sealed class NgChatCopilotChatCompletion : IChatCompletion
    {
        public IReadOnlyDictionary<string, string> Attributes { get; set; }
        public ChatHistory CreateNewChat(string? instructions = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<IChatResult>> GetChatCompletionsAsync(ChatHistory chat, AIRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<IChatStreamingResult> GetStreamingChatCompletionsAsync(ChatHistory chat, AIRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }


}
