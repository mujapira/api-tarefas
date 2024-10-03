using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Models;
using Services.Models.AppSettings;
using Services.Models.ExternalApisSettings;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarefas.Corp.Context;
using tarefas.Corp.Entities;
using tarefas.Models;

namespace Services.Services
{
    public class ChoreService : IChoreService
    {
        private readonly CorpContext _corpContext;

        public ChoreService(CorpContext corpContext)
        {
            _corpContext = corpContext;
        }

        public async Task<List<ChoreModel>> GetChores(long sessionId)
        {
            var choresEntity = await _corpContext.Chores.Where(x =>
            x.SessionId == sessionId
            ).ToListAsync();

            var choresResponse = new List<ChoreModel>();

            foreach (var chore in choresEntity)
            {
                choresResponse.Add(new ChoreModel
                {
                    Id = chore.Id,
                    Title = chore.Title,
                    Description = chore.Description,
                    IsCompleted = chore.IsCompleted,
                    CreatedAt = chore.CreatedAt
                });
            }

            return choresResponse;
        }

        public async Task CreateChore(ChoreFormData formData)
        {
            var choreEntity = new ChoreEntity
            {
                Title = formData.Title,
                Description = formData.Description,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow,
                SessionId = formData.SessionId
            };

            try
            {
                _corpContext.Chores.Add(choreEntity);
                await _corpContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar tarefa", ex);
            }
        }

        public async Task UpdateChore(long id)
        {
            var choreEntity = await _corpContext.Chores.FindAsync(id);
            if (choreEntity == null)
            {
                return;
            }

            choreEntity.IsCompleted = choreEntity.IsCompleted == true ? false : true;

            _corpContext.Chores.Update(choreEntity);
            await _corpContext.SaveChangesAsync();
        }

        public async Task DeleteChore(long id)
        {
            var choreEntity = await _corpContext.Chores.FindAsync(id);
            if (choreEntity == null)
            {
                return;
            }

            _corpContext.Chores.Remove(choreEntity);
            await _corpContext.SaveChangesAsync();
        }
    }
}
