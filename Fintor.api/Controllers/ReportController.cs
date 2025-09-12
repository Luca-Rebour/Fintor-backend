﻿using Application.DTOs.Reports;
using Application.DTOs.Transactions;
using Application.Interfaces.UseCases.Reports;
using Application.Interfaces.UseCases.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fintor.api.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportController : Controller
    {
        private readonly IGetOverviewResponse _getOverviewResponse;
        public ReportController(IGetOverviewResponse getOverviewResponse)
        {
            _getOverviewResponse = getOverviewResponse;
        }

        [HttpGet("get-overview")]
        [Authorize]
        public async Task<IActionResult> getOverview()
        {
            Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            OverviewResponseDTO overviewResponseDTO = await _getOverviewResponse.ExecuteAsync(userId);
            return Ok(overviewResponseDTO);
        }
    }
}
