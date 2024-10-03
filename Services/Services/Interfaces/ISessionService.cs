using System;
using Services.Models;

namespace Services.Services.Interfaces
{
    public interface ISessionService
    {
        Task<SessionModel> CreateSession();
        Task<bool> CheckSessionValidity(long sessionId);
        Task<bool> EndSession(long sessionId);
    }

}
