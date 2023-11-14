using Data.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface Credentia_Service
    {
        Task<CNA_Application> CreateCNA_ApplicationAsync(CreateCNA_ApplicationDto createCNA_ApplicatgionDto, string UserId);
        Task<bool> CandidateExistAsync(string UserId);
        Task<Candidate> CreateCandidateAsync(CreateCandidateDto addCandidateDto);
    }
}
