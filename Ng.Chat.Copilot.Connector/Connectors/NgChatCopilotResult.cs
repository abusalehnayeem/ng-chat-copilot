using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.SemanticKernel.AI.TextCompletion;
using Microsoft.SemanticKernel.Orchestration;

namespace Ng.Chat.Copilot.Connector.Connectors;

public sealed class NgChatCopilotResult(IAsyncEnumerable<string> text) : ITextStreamingResult
{
    public ModelResult ModelResult { get; set; } = new(text);

    public async IAsyncEnumerable<string> GetCompletionStreamingAsync(
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await foreach (var word in text.WithCancellation(cancellationToken)) yield return word;
    }

    public async Task<string> GetCompletionAsync(CancellationToken cancellationToken = default)
    {
        var sb = new StringBuilder();
        await foreach (var token in text.WithCancellation(cancellationToken)) sb.Append(token);
        return await Task.FromResult(sb.ToString()).ConfigureAwait(false);
    }
}