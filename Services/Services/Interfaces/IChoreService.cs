using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarefas.Models;

namespace Services.Services.Interfaces
{
    public interface IChoreService
    {
        Task<List<ChoreModel>> GetChores(long sessionId);
        Task CreateChore(ChoreFormData formData);
        Task UpdateChore(long id);
        Task DeleteChore(long id);
    }

}
