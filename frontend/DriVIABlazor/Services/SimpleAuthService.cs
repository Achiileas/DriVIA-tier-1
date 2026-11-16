using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace DriVIABlazor.Services;

public class SimpleAuthService : AuthenticationStateProvider
{
    private ClaimsPrincipal currentUser = new(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(currentUser));
    }

    // Login with username and role
    public void Login(string username, string role)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };

        var identity = new ClaimsIdentity(claims, "SimpleAuth");
        currentUser = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    
    public void Login(string username)
    {
        Login(username, "CUSTOMER");
    }

    public void Logout()
    {
        currentUser = new ClaimsPrincipal(new ClaimsIdentity());

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}