using System;
using System.Text.Json.Serialization;

namespace Infrastructure.Response
{
    /// <summary>
    /// Generic authentication response model to be serialized as json response to http requests.
    /// </summary>
    public class AuthenticationResponseModel
    {
        /// <summary>
        /// Authenticated user's email address.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Access token to be used in subsequent request headers.
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Refresh token to be used to refresh tokens.
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Token type: Bearer
        /// </summary>
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Total seconds which access token get expires  
        /// </summary>
        [JsonPropertyName("expires")]
        public int Expires { get; set; }

        /// <summary>
        /// Refresh token's expiration date time against the UTC timezone.
        /// </summary>
        [JsonPropertyName("refresh_token_expires_at")]
        public DateTimeOffset RefreshTokenExpiresAt { get; set; }

        /// <summary>
        /// Authentication scope.
        /// </summary>
        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        public AuthenticationResponseModel()
        {
            TokenType = "Bearer";
        }
    }
}