﻿using Microsoft.AspNetCore.Mvc;
using TestApplication.DTO_s;
using TestApplication.Services;
using TestApplication.Interfaces.Operations;

namespace TestApplication.Controllers
{
    [Route("api/operation")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService;

        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpPost("{crashId}")]
        public async Task<IActionResult> Create(Guid crashId, [FromForm] string description)
        {
            var result = await _operationService.Create(crashId, description);

            if (result.IsFailure)
            {
                return BadRequest(new { Error = result.Error });
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(OperationDTO operationDTO)
        {
            var result = await _operationService.Update(operationDTO);

            if (result.IsFailure)
            {
                return BadRequest(new { Error = result.Error });
            }

            return Ok();
        }

        [HttpGet("{crashId}")]
        public async Task<IActionResult> GetByCrashId(Guid crashId)
        {
            var result = await _operationService.GetByCrashId(crashId);

            if (result.IsFailure)
            {
                return NotFound(new { Error = result.Error });
            }

            return Ok(result.Value);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var result = await _operationService.Remove(Id);

            if (result.IsFailure)
            {
                return BadRequest(new { Error = result.Error });
            }

            return Ok();
        }
    }
}