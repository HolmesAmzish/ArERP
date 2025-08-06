using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace ArERP.Service;

public interface IAgentService
{
    Task<string> AskAsync(string userInput, ChatHistory history);
    IAsyncEnumerable<StreamingChatMessageContent> GetStreamingReplyAsync(ChatHistory history);
}
