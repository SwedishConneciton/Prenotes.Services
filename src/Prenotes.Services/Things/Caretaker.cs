
namespace Prenotes.Services.Things {

    public class Caretaker : User {

        /// <summary>
        /// Children
        /// </summary>
        public readonly Child[] children; 

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="email"></param>
        /// <param name="created"></param>
        /// <param name="name"></param>
        public Caretaker(string email, int created, string name, Child[] children) : base(email, created, name) {
            this.children = children;
        }

        /// <summary>
        /// Email and at least one child should be provided
        /// </summary>
        /// <param name="email"></param>
        /// <param name="children"></param>
        public Caretaker(string email, Child[] children): this(email, 0, null, children) {
        }
    }
}