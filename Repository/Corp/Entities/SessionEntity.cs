using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarefas.Corp.Entities
{
    public partial class SessionEntity
    {
        public int SessionId { get; set; }
        public string UserNickName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
