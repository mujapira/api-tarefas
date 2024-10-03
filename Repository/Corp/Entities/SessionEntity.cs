using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarefas.Corp.Entities
{
    public partial class SessionEntity
    {
        public long SessionId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
