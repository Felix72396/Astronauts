﻿
namespace Astronauts.Core.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IAstronautRepository AstronautRepository { get; }
    IMissionRepository MissionRepository { get; }
    ISecurityRepository SecurityRepository { get; }
    void SaveChanges();
    Task SaveChangesAsync();
}
