using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Services;

namespace StockAppWebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CoveredWarrantController : ControllerBase
{
    readonly ICoveredWarrantService _service;
    public CoveredWarrantController(ICoveredWarrantService service)
    {
        _service = service;
    }
    [HttpGet("stock/{stockId}")]
    public async Task<IActionResult> GetCoveredWarrantByStockId(int stockId)
    {
        try
        {
            var cw = await _service.GetCoveredWarrantsByStockId(stockId);
            return Ok(cw);
        }
        catch (Exception e)
        {

            return StatusCode(500,$"An error occurred: {e.Message}");
        }
        
    }
}
