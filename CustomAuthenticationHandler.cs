using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace BlazorAuth2
{
    public class CustomAuthenticationHandler(IOptionsMonitor<CustomAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder)
        : AuthenticationHandler<CustomAuthOptions>(options, logger, encoder)
    {

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(new ClaimsPrincipal(new GenericIdentity("CustomIdentity")), "CustomAuthenticationScheme")));
        }
    }

    public class CustomAuthOptions : AuthenticationSchemeOptions
    {
        // Add any custom options here if needed in the future
    }
}