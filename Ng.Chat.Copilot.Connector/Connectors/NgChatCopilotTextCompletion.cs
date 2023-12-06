using Microsoft.SemanticKernel.AI;
using Microsoft.SemanticKernel.AI.TextCompletion;

namespace Ng.Chat.Copilot.Connector.Connectors;

public sealed class NgChatCopilotTextCompletion(string modelPath) : ITextCompletion
{
    private readonly string _modelPath = modelPath;

    public IReadOnlyDictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();

    public async Task<IReadOnlyList<ITextResult>> GetCompletionsAsync(string text,
        AIRequestSettings? requestSettings = null,
        CancellationToken cancellationToken = default)
    {
        return await Task.FromResult<IReadOnlyList<ITextResult>>(new List<ITextResult>
        {
            new MyTextCompletionStreamingResult()
        });
    }

    public IAsyncEnumerable<ITextStreamingResult> GetStreamingCompletionsAsync(string text,
        AIRequestSettings? requestSettings = null,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}