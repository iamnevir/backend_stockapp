using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Models;
using StockAppWebApi.Services;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace StockAppWebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class QuoteController : ControllerBase
{
    readonly IQuoteService _service;
    public QuoteController(IQuoteService service)
    {
        _service = service;
    }
    [HttpGet("historical")]
    public async Task<IActionResult> GetHistoricalQuotes(
        int days,
        int stockId)
    {
        var historicalQuotes = await _service.GetHistoricalQuotes(days,stockId);
        return Ok(historicalQuotes);
    }
    [HttpGet("ws")]
    public async Task GetRealTimeQuotes(
        int page=1,
        int limit=10,
        string sector="",
        string industry="")
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            while (webSocket.State==WebSocketState.Open)
            {
                List<ViewQuotesRealtime>? quotes = await _service.GetViewQuotesRealtimes(
                    page,
                    limit,
                    sector,
                    industry);
                string jsonString  = JsonSerializer.Serialize(quotes);
                var buffer = Encoding.UTF8.GetBytes(jsonString);
                await webSocket.SendAsync(new ArraySegment<byte>(buffer)
                    ,WebSocketMessageType.Text,true,CancellationToken.None);
                await Task.Delay(2000);
            }
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure,
                "Connection closed by the server",CancellationToken.None);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest; return;
        }
    }
}
