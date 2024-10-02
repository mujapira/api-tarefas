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

        public async Task<List<ChoreModel>> GetChores(int sessionId)
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

            _corpContext.Chores.Add(choreEntity);
            await _corpContext.SaveChangesAsync();
        }

        public async Task<ChoreModel> GetChoreById(int id)
        {
            var choreEntity = await _corpContext.Chores.FindAsync(id);
            if (choreEntity == null)
            {
                return null;
            }

            return new ChoreModel
            {
                Id = choreEntity.Id,
                Title = choreEntity.Title,
                Description = choreEntity.Description,
                IsCompleted = choreEntity.IsCompleted,
                CreatedAt = choreEntity.CreatedAt
            };
        }

        public async Task<ChoreModel> UpdateChore(int id, ChoreModel model)
        {
            var choreEntity = await _corpContext.Chores.FindAsync(id);
            if (choreEntity == null)
            {
                return null;
            }

            choreEntity.Title = model.Title;
            choreEntity.Description = model.Description;
            choreEntity.IsCompleted = model.IsCompleted;

            _corpContext.Chores.Update(choreEntity);
            await _corpContext.SaveChangesAsync();

            return model;
        }

        public async Task<bool> DeleteChore(int id)
        {
            var choreEntity = await _corpContext.Chores.FindAsync(id);
            if (choreEntity == null)
            {
                return false;
            }

            _corpContext.Chores.Remove(choreEntity);
            await _corpContext.SaveChangesAsync();

            return true;
        }
    }
}
