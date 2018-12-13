using System.Net;
using Skybrud.Social.Http;
using Skybrud.Social.Sonos.Exceptions;

namespace Skybrud.Social.Sonos.Responses {
    
    /// <summary>
    /// Class representing a response from the Sonos API.
    /// </summary>
    public abstract class SonosResponse : SocialResponse {

        #region Properties

        /// <summary>
        /// Gets a collection of the HTTP headers of the response.
        /// </summary>
        public new SonosResponseHeaders Headers { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response.</param>
        protected SonosResponse(SocialHttpResponse response) : base(response) {
            Headers = new SonosResponseHeaders(response);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(SocialHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            // Now throw some exceptions
            throw new SonosHttpException(response);

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the Sonos API.
    /// </summary>
    public class SonosResponse<T> : SonosResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response.</param>
        protected SonosResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}