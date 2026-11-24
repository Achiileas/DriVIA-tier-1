using DriVIABlazor.Models;

namespace DriVIABlazor.Services;

public interface IRegistrationService
{
    Task<bool> RegisterAsync(RegistrationRequest request);
}