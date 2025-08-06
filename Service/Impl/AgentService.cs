using System.Text;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace ArERP.Service.Impl;

public class AgentService : IAgentService
{
    private readonly Kernel _kernel;
    private readonly IChatCompletionService _chat;

    public AgentService()
    {
        var builder = Kernel.CreateBuilder();
        builder.AddOpenAIChatCompletion(
            modelId: "deepseek-chat",
            apiKey: "sk-4b000508562e49439467081a078c7049",
            endpoint: new Uri("https://api.deepseek.com/v1"),
            // modelId: "deepseek/deepseek-chat-v3-0324:free",
            // apiKey: "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",
            // endpoint: new Uri("https://openrouter.ai/api/v1"), // Used to point to your service
            serviceId: "SERVICE_ID", // Optional; for targeting specific services within Semantic Kernel
            httpClient: new HttpClient() // Optional; for customizing HTTP client
        );

        _kernel = builder.Build();
        _chat = _kernel.GetRequiredService<IChatCompletionService>();
    }

    public async Task<string> AskAsync(string userInput, ChatHistory history)
    {
        history.AddUserMessage(userInput);
        var responseBuilder = new StringBuilder();
        await foreach (var message in _chat.GetStreamingChatMessageContentsAsync(history))
        {
            responseBuilder.Append(message.Content);
        }

        var reply = responseBuilder.ToString();
        history.AddAssistantMessage(reply);
        return reply;
    }
    
    public IAsyncEnumerable<StreamingChatMessageContent> GetStreamingReplyAsync(ChatHistory history)
    {
        return _chat.GetStreamingChatMessageContentsAsync(history);
    }

    
}