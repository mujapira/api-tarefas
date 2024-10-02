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
    public class SessionService : ISessionService
    {
        private readonly CorpContext _corpContext;

        public SessionService(CorpContext corpContext)
        {
            _corpContext = corpContext;
        }

        public async Task<SessionModel> CreateSession()
        {
            var session = new SessionEntity
            {
                UserNickName = "",
                CreatedAt = DateTime.UtcNow
            };

            _corpContext.Sessions.Add(session);
            await _corpContext.SaveChangesAsync();

            return new SessionModel { SessionId = session.SessionId, UserNickName = session.UserNickName };
        }

        public async Task<bool> GetSession(int sessionId)
        {
            var session = await _corpContext.Sessions.FindAsync(sessionId);
            if (session == null)
                return true;

            return false;
        }

        public async Task<bool> EndSession(int sessionId)
        {
            var session = await _corpContext.Sessions.FindAsync(sessionId);
            if (session == null)
                return false;

            _corpContext.Sessions.Remove(session);
            await _corpContext.SaveChangesAsync();
            return true;
        }


    }
}
