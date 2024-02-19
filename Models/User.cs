using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string LevelOfApprenticeship { get; set; }
        public string JobRole { get; set; }
        public string Organisation { get; set; } 
        public string Email { get; set; }
        
    }
}
