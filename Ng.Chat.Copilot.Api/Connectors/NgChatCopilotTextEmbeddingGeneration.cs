using Microsoft.SemanticKernel.AI.Embeddings;

namespace Ng.Chat.Copilot.Api.Connectors
{
    public sealed class NgChatCopilotTextEmbeddingGeneration : ITextEmbeddingGeneration
    {
        public async Task<IList<ReadOnlyMemory<float>>> GenerateEmbeddingsAsync(IList<string> data, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public IReadOnlyDictionary<string, string> Attributes { get; set; }
    }
}
