using Microsoft.SemanticKernel.AI.Embeddings;

namespace Ng.Chat.Copilot.Api.Connectors
{
    public sealed class NgChatCopilotTextEmbeddingGeneration(string modelPath) : ITextEmbeddingGeneration
    {
        private readonly string _modelPath = modelPath;

        public IReadOnlyDictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();

        public async Task<IList<ReadOnlyMemory<float>>> GenerateEmbeddingsAsync(IList<string> data, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}
