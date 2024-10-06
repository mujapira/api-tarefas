using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ChoreFormData
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid SessionId { get; set; }
    }
}
