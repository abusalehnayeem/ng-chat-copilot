
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.AI.ChatCompletion;
using Microsoft.SemanticKernel.AI.Embeddings;
using Microsoft.SemanticKernel.AI.TextCompletion;
using Ng.Chat.Copilot.Connector.Connectors;

namespace Ng.Chat.Copilot.Api.Services;

public static class ServicesConfiguration
{
    private static string GetModelPath(this IConfiguration configuration) => configuration["Ai-Model"]!;

    public static IServiceCollection ConfigureSemanticKernelService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IKernel>(sp =>
        {
            var kernel = new KernelBuilder()
                .WithAIService<ITextCompletion>("text_completion", new NgChatCopilotTextCompletion(configuration.GetModelPath()))
                .WithAIService<IChatCompletion>("chat_completion", new NgChatCopilotChatCompletion(configuration.GetModelPath()))
                .WithAIService<ITextEmbeddingGeneration>("text_embedding_generation",new NgChatCopilotTextEmbeddingGeneration(configuration.GetModelPath()))

                .Build();
            return kernel;
        });
        return services;
    }
}