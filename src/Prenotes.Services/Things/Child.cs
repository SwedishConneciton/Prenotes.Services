
namespace Prenotes.Services.Things {

    public class Child {
        
        /// <summary>
        /// Same rules apply as in the User's name property
        /// and this property (field) is not unique
        /// </summary>
        public readonly string name;

        /// <summary>
        /// Nickname is optional but helpful if we children
        /// at a Daycare with the same name
        /// </summary>
        public readonly string nickname;

        /// <summary>
        /// When the child was registered
        /// </summary>
        public readonly long created;

        // TODO: Look at the constructor and the comments
        //       on the properties to get a feel of what 
        //       defines a child.
        public Child(string name, string nickname, long created) {
            this.name = name;
            this.nickname = nickname;
            this.created = created;
        }

        public Child(string name) {
            this.name = name;
            this.nickname = null;
            this.created = 0;
        } 
    }
}