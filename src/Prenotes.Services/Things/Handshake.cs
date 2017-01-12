
namespace Prenotes.Services.Things {

    public class Handshake {

        /// <summary>
        /// Code that is issued by an employee for another user
        /// </summary>
        public readonly int code;

        /// <summary>
        /// Email that should be confirmed
        /// </summary>
        public readonly string email;

        /// <summary>
        /// When the handshake was confirmed (Unix epoch)
        /// </summary>
        public readonly long confirmed;

        /// <remarks>
        /// todo: The properties of this class are readonly which
        /// means that the public constructor is the only place 
        /// where we can set properties.  Finish off the constructor
        /// with arguements and set the propreties.
        /// </remarks>
        public Handshake () {

        }
    }
}