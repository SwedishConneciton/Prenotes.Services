
namespace Prenotes.Services.Things {

    public class Child {
        
        /// <summary>
        /// Same rules apply as in the User's name property
        /// and this field is not considered unique
        /// </summary>
        public readonly string name;

        /// <summary>
        /// Nickname is optional although helpful if several children
        /// at the same daycare share a name
        /// </summary>
        public readonly string nickname;

        /// <summary>
        /// When the child was registered
        /// </summary>
        public readonly int created;

        /// <summary>
        /// Registered daycare which should not be null
        /// </summary>
        public readonly Daycare daycare;

        /// <summary>
        /// Caretakers
        /// </summary>
        public readonly Caretaker[] caretakers;

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nickname"></param>
        /// <param name="created"></param>
        /// <param name="daycare"></param>
        /// <param name="caretakers"></param>
        public Child(string name, string nickname, int created, Daycare daycare, Caretaker[] caretakers) {
            this.name = name;
            this.nickname = nickname;
            this.created = created;
            this.daycare = daycare;
            this.caretakers = caretakers;
        }

        /// <summary>
        /// Name and daycare should be provided
        /// </summary>
        /// <param name="name"></param>
        /// <param name="daycare"></param>
        public Child(string name, Daycare daycare) : this(name, null, 0, daycare, null) {
        } 
    }
}