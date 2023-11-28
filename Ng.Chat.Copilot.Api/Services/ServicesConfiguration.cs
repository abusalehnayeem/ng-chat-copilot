using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.AI.ChatCompletion;
using Microsoft.SemanticKernel.AI.Embeddings;
using Microsoft.SemanticKernel.AI.TextCompletion;
using Ng.Chat.Copilot.Api.Connectors;

namespace Ng.Chat.Copilot.Api.Services;

public static class ServicesConfiguration
{
    private static string GetModelPath(this IConfiguration configuration)
    {
        return configuration["Ai-Model"] ?? throw new InvalidOperationException();
    }

    public static IServiceCollection ConfigureSemanticKernelService(this IServiceCollection services,
        IConfiguration configuration)
    {
        //services.AddSingleton<IMemoryStore, VolatileMemoryStore>();
        services.AddSingleton<IKernel>(sp =>
        {
            var kernel = new KernelBuilder()
                .WithAIService<ITextCompletion>("text_completion", new NgChatCopilotTextCompletion())
                .WithAIService<IChatCompletion>("chat_completion", new NgChatCopilotChatCompletion())
                .WithAIService<ITextEmbeddingGeneration>("text_embedding_generation",
                    new NgChatCopilotTextEmbeddingGeneration())
                .Build();
            return kernel;
        });
        return services;
    }
}