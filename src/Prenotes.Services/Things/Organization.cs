
namespace Prenotes.Services.Things {
    
    public class Organization {

        /// <summary>
        /// Unique identifier
        /// </summary>
        public readonly string name;

        /// <summary>
        /// When the orgization was registered
        /// </summary>
        public readonly int created;

        public Organization(string name, int created) {
            this.name = name;
            this.created = created;
        }
    }
}