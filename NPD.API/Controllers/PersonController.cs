using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPD.API.Application.Commands;
using NPD.Domain.DTOs;

namespace NPD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            //throw new Exception("chatch this");
            return Ok("pong");
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]CreatePersonCommand createPersonCommand)
        {
            var result = await _mediator.Send(createPersonCommand);

            if (!result)
                return BadRequest();

            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdatePersonCommand updatePersonCommand)
        {
            var result = await _mediator.Send(updatePersonCommand);

            return Ok(result);
        }

        [HttpPost("uploadPicture")]
        public async Task<IActionResult> UploadPictureAsync([FromBody]UploadPictureCommand uploadPictureCommand)
        {
            var result = await _mediator.Send(uploadPictureCommand);

            return Ok(result);
        }

        [HttpPost("addrelatedperson")]
        public async Task<IActionResult> AddRelatedAsync([FromBody]AddRelatedPersonCommand addRelatedPersonCommand)
        {
            var result = await _mediator.Send(addRelatedPersonCommand);

            return Ok(result);
        }

        [HttpDelete("{PersonId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]DeletePeronCommand deletePeronCommand)
        {
            var result = await _mediator.Send(deletePeronCommand);

            return Ok(result);
        }

        [HttpGet("Full/{PersonId}")]
        public async Task<IActionResult> GetPersonFullInfoAsync([FromRoute]GetPersonFullInfoCommand getPersonFullInfoCommand)
        {
            var result = await _mediator.Send(getPersonFullInfoCommand);

            return Ok(result);
        }

        //repository.search - done
        //repository.report - done
    }
}