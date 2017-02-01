
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
        /// When the handshake was created (Unix epoch)
        /// </summary>
        public readonly int created;

        /// <summary>
        /// When the handshake was confirmed (Unix epoch)
        /// </summary>
        public readonly int confirmed;

        /// <summary>
        /// Full constructor
        /// </summary>
        public Handshake (string email, int code, int created, int confirmed) {
            this.email = email;
            this.code = code;
            this.created = created;
            this.confirmed = confirmed;
        }

        /// <summary>
        /// Email and code should be provided
        /// </summary>
        /// <param name="email"></param>
        /// <param name="code"></param>
        public Handshake (string email, int code): this(email, code, 0, 0) {

        }
    }
}