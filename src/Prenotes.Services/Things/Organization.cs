
namespace Prenotes.Services.Things {
    
    public class Organization {

        public readonly string name;

        public readonly long created;

        public Organization(string name, long created) {
            this.name = name;
            this.created = created;
        }
    }
}