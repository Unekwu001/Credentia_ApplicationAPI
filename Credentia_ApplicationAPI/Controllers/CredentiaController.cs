using Core;
using Data.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentiaController : ControllerBase
    {
        private readonly Credentia_Service _credentiaService;

        public CredentiaController(Credentia_Service credentiaService)
        {
            _credentiaService = credentiaService;
        }



        [HttpPost("add-a-candidate")]
        public async Task<IActionResult> AddCandidate([FromBody] CreateCandidateDto addCandidateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse.Failed(ModelState, "Invalid input"));
                }
                var CandidateExist = await _credentiaService.CandidateExistAsync(addCandidateDto.Email);
                if (CandidateExist == true)
                {
                    return BadRequest(ApiResponse.Failed("Candidate already exists"));
                }

                var freshApplication = await _credentiaService.CreateCandidateAsync(addCandidateDto);
                if (freshApplication != null)
                {
                    return Ok(ApiResponse.Success("Candidate registered successfully"));
                }
                else
                {
                    return BadRequest(ApiResponse.Failed(ModelState));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Failed(ModelState, $"{ex}"));
            }
        }





        [HttpPost("create-CNA_application")]
        public async Task<IActionResult> CreateCNA_application([FromBody] CreateCNA_ApplicationDto createCNA_ApplicationDto,string UserId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse.Failed(ModelState, "Invalid input"));
                }
                var CandidateExist = await _credentiaService.CandidateExistAsync(UserId);
                if (CandidateExist == false)
                {
                    return NotFound(ApiResponse.Failed("Candidate not found"));
                }

                var freshApplication = await _credentiaService.CreateCNA_ApplicationAsync(createCNA_ApplicationDto,UserId);
                if (freshApplication != null)
                {
                    return Ok(ApiResponse.Success("Your Application has been successfully submitted"));
                }
                else
                {
                    return BadRequest(ApiResponse.Failed(ModelState));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Failed(ModelState, $"{ex}"));
            }
        }



    }
}
