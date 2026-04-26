using Arkitektur.WebUI.Services.TokenServices;
using Microsoft.AspNetCore.Authentication;
using System.Net;
using System.Net.Http.Headers;

namespace Arkitektur.WebUI.Handlers
{
    public class TokenHandler(IHttpContextAccessor _httpContextAccessor,ITokenService _tokenService) :DelegatingHandler
    {

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.GetUserToken);

            var response = await base.SendAsync(request, cancellationToken);

            if(response.StatusCode ==HttpStatusCode.Unauthorized)
            {
                await _httpContextAccessor.HttpContext.SignOutAsync();

                _httpContextAccessor.HttpContext.Response.Redirect("/Auth/Login");


            }

            return response;

        }







    }
}
