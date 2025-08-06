using System.Text;
using ArERP.Service;
using ArERP.Service.Impl;

namespace ArERP.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel.ChatCompletion;

public class AgentController : Controller
{
    private readonly IAgentService _agentService;
    private static readonly ChatHistory _chatHistory = new();

    public AgentController(IAgentService agentService)
    {
        _agentService = agentService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Ask(string userInput)
    {
        var reply = await _agentService.AskAsync(userInput, _chatHistory);
        ViewBag.UserInput = userInput;
        ViewBag.Reply = reply;
        ViewBag.History = _chatHistory;
        return View("Index");
    }
    [HttpGet("stream")]
    public async Task Stream(string userInput)
    {
        Response.ContentType = "text/event-stream";
        Response.Headers.Add("Cache-Control", "no-cache");
        Response.Headers.Add("X-Accel-Buffering", "no");

        var history = new ChatHistory();
        history.AddUserMessage(userInput);

        var replyBuilder = new StringBuilder();

        await foreach (var message in _agentService.GetStreamingReplyAsync(history))
        {
            replyBuilder.Append(message.Content);

            var content = message.Content?.Replace("\n", "<br/>");
            if (!string.IsNullOrEmpty(content))
            {
                await Response.WriteAsync($"data: {content}\n\n");
                await Response.Body.FlushAsync();
            }
        }

        history.AddAssistantMessage(replyBuilder.ToString());
    }

}
