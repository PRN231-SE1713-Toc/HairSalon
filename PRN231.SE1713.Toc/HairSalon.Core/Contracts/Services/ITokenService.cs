using System.Security.Claims;

namespace HairSalon.Core.Contracts.Services
{
    public interface ITokenService
    {
        /// <summary>
        /// Generates an access token based on the provided claims.
        /// </summary>
        /// <param name="claims">The claims to include in the access token.</param>
        /// <returns>The generated access token.</returns>
        string GenerateAccessToken(IEnumerable<Claim> claims);

        /// <summary>
        /// Generates a refresh token.
        /// </summary>
        /// <returns>The generated refresh token.</returns>
        string GenerateRefreshToken();  // METHOD IS NOT USED IN THIS CONTEXT

        /// <summary>
        /// Retrieves a ClaimsPrincipal object from an expired token.
        /// </summary>
        /// <param name="token">The expired token.</param>
        /// <returns>The ClaimsPrincipal object representing the identity of the user.</returns>
        ClaimsPrincipal GetPrincipalFromAccessToken(string token);  // METHOD IS NOT USED IN THIS CONTEXT
    }
}
