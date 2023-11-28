using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.SemanticKernel.AI.TextCompletion;
using Microsoft.SemanticKernel.Orchestration;

namespace Ng.Chat.Copilot.Api.Connectors;

public sealed class NgChatCopilotResult : ITextStreamingResult
{
    private readonly IAsyncEnumerable<string> _text;

    public NgChatCopilotResult(IAsyncEnumerable<string> text)
    {
        _text = text;
        ModelResult = new ModelResult(text);
    }

    public ModelResult ModelResult { get; set; }

    public async IAsyncEnumerable<string> GetCompletionStreamingAsync(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (var word in _text.WithCancellation(cancellationToken)) yield return word;
    }

    public async Task<string> GetCompletionAsync(CancellationToken cancellationToken = default)
    {
        var sb = new StringBuilder();
        await foreach (var token in _text.WithCancellation(cancellationToken)) sb.Append(token);
        return await Task.FromResult(sb.ToString()).ConfigureAwait(false);
    }
}