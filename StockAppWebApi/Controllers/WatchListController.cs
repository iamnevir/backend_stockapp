﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StockAppWebApi.Attributes;
using StockAppWebApi.Extensions;
using StockAppWebApi.Services;
using System.Security.Claims;

namespace StockAppWebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WatchListController : ControllerBase
{
    private readonly IWatchListService _watchListService;
    private readonly IUserService _userService;
    private readonly IStockService _stockService;

    public WatchListController(IWatchListService watchListService, 
        IUserService userService,
        IStockService stockService)
    {
        _watchListService = watchListService;
        _userService = userService;
        _stockService = stockService;
    }
    [HttpPost("AddStockToWatchList/{stockId}")]
    [JwtAuthorize]
    public async Task<IActionResult> AddStockToWatchList(int stockId)
    {
        int userId = HttpContext.GetUserId();
        var user = await _userService.GetUserById(userId);
        var stock = await _stockService.GetStockById(stockId);
        if (stock == null)
        {
            return NotFound("Stock not found.");
        }
        if (user == null)
        {
            return NotFound("User not found.");
        }
        var existingWatchListItem = await _watchListService.GetWatchListItem(userId, stockId);
        if (existingWatchListItem != null)
        {
            return BadRequest("Stock is already in watchlist.");
        }
        try
        {
            await _watchListService.AddStockToWatchList(userId,stockId);
            return Ok();   
        }
        catch (ArgumentException e)
        {

            return BadRequest(new { e.Message });
        }
    }
}
