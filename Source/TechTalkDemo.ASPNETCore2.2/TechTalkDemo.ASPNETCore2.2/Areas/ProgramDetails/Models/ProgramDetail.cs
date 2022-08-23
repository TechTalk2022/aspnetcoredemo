using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTalkDemo.ASPNETCore2._2.Areas.ProgramDetails.Models
{
    public class ProgramDetail
    {
         
            public Int32 ProgramId { get; set; }
            public Int32 StartYear { get; set; }
            public string ProgramCode { get; set; }
            public string ProgramName { get; set; }
            public string ProgramDesc { get; set; }
            public int Duration { get; set; }
            public string ProgramType { get; set; }
            public int IsDelete { get; set; }
        
    }
}
  