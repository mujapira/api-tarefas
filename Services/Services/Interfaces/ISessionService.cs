using System;
using Services.Models;

namespace Services.Services.Interfaces
{
    public interface ISessionService
    {
        Task<SessionModel> CreateSession();
        Task<bool> GetSession(int sessionId);
        Task<bool> EndSession(int sessionId);
    }

}
