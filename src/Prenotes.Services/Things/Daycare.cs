
namespace Prenotes.Services.Things {

    public class Daycare {

        /// <summary>
        /// Unique identier
        /// </summary>
        public readonly string name;

        /// <summary>
        /// When the daycare was registered
        /// </summary>
        public readonly long created;

        public Daycare(string name, long created) {
            this.name = name;
            this.created = created;
        }
    }
}