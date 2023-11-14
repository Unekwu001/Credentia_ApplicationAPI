using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class CreateCNA_ApplicationDto
    {
        [Required]
        public string EligibilityRoute { get; set; }
        [Required]
        public string TrainingProgram { get; set; }
        [Required]
        public DateTime CourseCompletionDate { get; set; }
        [Required]
        public bool Accomodation { get; set; }
       
    }
}
