using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class CNA_Application : BaseEntity
    {
        public string EligibilityRoute { get; set; }
        public string TrainingProgram { get; set; }
        public DateTime CourseCompletionDate { get; set; }
        public bool Accomodation { get; set; }
        public bool IsApproved { get; set; }
        public string CandidateId { get; set; }
        public Candidate Candidate { get; set; }

    }
}
