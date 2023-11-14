using Data.AppDbContext;
using Data.Dtos;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Credentia_Repo : Credentia_Service
    {
        private readonly CredentiaDbContext _credentiaDbContext;

        public Credentia_Repo(CredentiaDbContext credentiaDbContext)
        {
            _credentiaDbContext = credentiaDbContext;
        }


        public async Task<CNA_Application> CreateCNA_ApplicationAsync(CreateCNA_ApplicationDto createCNA_ApplicatgionDto, string UserId)
        {
            var freshApplication = new CNA_Application()
            {
                Id = Guid.NewGuid().ToString(),
                EligibilityRoute = createCNA_ApplicatgionDto.EligibilityRoute,
                TrainingProgram = createCNA_ApplicatgionDto.TrainingProgram,
                CourseCompletionDate = createCNA_ApplicatgionDto.CourseCompletionDate,
                Accomodation = createCNA_ApplicatgionDto.Accomodation,
                IsApproved = false,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CandidateId = UserId             
            };
            _credentiaDbContext.CNA_Applications.Add(freshApplication);
            await _credentiaDbContext.SaveChangesAsync();
            return freshApplication;
        }



        public async Task<bool> CandidateExistAsync(string UserId)
        {
            var candidateExist = await _credentiaDbContext.Candidates.SingleOrDefaultAsync(candidate => candidate.Id == UserId);

            if (candidateExist != null)
            {
                return true;
            }
            return false;
        }


        public async Task<Candidate> CreateCandidateAsync(CreateCandidateDto addCandidateDto)
        {
            var createdCandidate = new Candidate()
            {
                Name = addCandidateDto.Name,
                PhoneNumber = addCandidateDto.PhoneNumber,
                Email = addCandidateDto.Email,
                Address = addCandidateDto.Address,
                Id = Guid.NewGuid().ToString(),
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            _credentiaDbContext.Candidates.Add(createdCandidate);
            await _credentiaDbContext.SaveChangesAsync();
            return createdCandidate;
        }





    }
}
