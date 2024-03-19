using Microsoft.SemanticKernel;

namespace Ng.Chat.Copilot.Api.Services;

public static class ServicesConfiguration
{
    private static string GetModelPath(this IConfiguration configuration)
    {
        return configuration["Ai-Model"]!;
    }

    public static void ConfigureSemanticKernelService(this IServiceCollection services, IConfiguration configuration)
    {
        var kernel = new KernelBuilder().Build();
    }
}