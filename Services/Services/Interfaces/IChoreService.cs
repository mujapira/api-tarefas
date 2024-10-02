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
        Task<List<ChoreModel>> GetChores(int sessionId);
        Task<ChoreModel> GetChoreById(int id);
        Task CreateChore(ChoreFormData formData);
        Task<ChoreModel> UpdateChore(int id, ChoreModel model);
        Task<bool> DeleteChore(int id);
    }

}
