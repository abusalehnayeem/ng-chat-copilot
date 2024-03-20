using LLama;
using LLama.Common;

var @params = new ModelParams("D:\\Personal-Projects\\llm-test\\ng-chat-copilot\\ai-model\\zephyr-7b-beta.Q6_K.gguf");

using var weights = LLamaWeights.LoadFromFile(@params);

// Create context
using var llamaCtx = weights.CreateContext(@params);
var executor = new InteractiveExecutor(llamaCtx);
//var chatSession = new ChatSession(executor);

// show the prompt
var prompt =
    @"Transcript of a dialog, where the User interacts with an Assistant named Bob. Bob is helpful, 
kind, honest, good at writing, 
and never fails to answer the User's requests immediately and with precision.\r\n\r\nUser: Hello, Bob.\r\nBob: Hello. How may I help you today?\r\nUser: Please tell me the largest city in Europe.\r\nBob: Sure. The largest city in Europe is Moscow, the capital of Russia.\r\nUser:"; // use the "chat-with-bob" prompt here.
Console.WriteLine();
Console.Write(prompt);

// run the inference in a loop to chat with LLM
var inferenceParams = new InferenceParams
{
    Temperature = 0.9f,
    AntiPrompts = new List<string> { "User:" },
    MaxTokens = 500
};


while (true)
{
    await foreach (var text in executor.InferAsync(prompt, inferenceParams)) Console.Write(text);

    Console.ForegroundColor = ConsoleColor.Green;
    prompt = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.White;
}


//async Task<string> Prompt(ILLamaExecutor executor, ConsoleColor color, string prompt, bool showPrompt, bool showResponse)
//{
//    var inferenceParams = new InferenceParams
//    {
//        Temperature = 0.9f,
//        AntiPrompts = new List<string> { "Alice:", "Bob:", "User:" },
//        MaxTokens = 128,
//        Mirostat = MirostatType.Mirostat2,
//        MirostatTau = 10,
//    };

//    Console.ForegroundColor = ConsoleColor.White;
//    if (showPrompt)
//        Console.Write(prompt);

//    Console.ForegroundColor = color;
//    var builder = new StringBuilder();
//    await foreach (var text in executor.InferAsync(prompt, inferenceParams))
//    {
//        builder.Append(text);
//        if (showResponse)
//            Console.Write(text);
//    }

//    return builder.ToString();
//}