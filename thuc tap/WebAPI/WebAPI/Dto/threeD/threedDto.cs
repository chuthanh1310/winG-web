using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Dto.threeD
{
    public class threedDto
    {
        public int ID{get;set;}
        public string Name { get; set; } = string.Empty;
        public int? ProductID { get; set; }
    }
}