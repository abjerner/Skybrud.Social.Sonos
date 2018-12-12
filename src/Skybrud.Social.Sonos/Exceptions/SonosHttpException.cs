using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Sonos.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Sonos API.
    /// </summary>
    public class SonosHttpException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="SocialHttpResponse"/>.
        /// </summary>
        public SocialHttpResponse Response { get; }
        
        #endregion

        #region Constructors
        
        internal SonosHttpException(SocialHttpResponse response) {
            Response = response;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the message of the exception.
        /// </summary>
        public override string Message {
            get {
                string message = "Invalid response received from the Sonos API (Status: " + ((int) Response.StatusCode) + ")";
                return message;
            }
        }

        #endregion

    }

}