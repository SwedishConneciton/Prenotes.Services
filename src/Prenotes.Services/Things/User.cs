
namespace Prenotes.Services.Things
{
    public abstract class User {

        /// <summary>
        /// Unique identifier
        /// </summary>
        public readonly string email;

        /// <summary>
        /// Unix epoch when the User was registered
        /// </summary>
        public readonly long created;

        /// <summary>
        /// Forname, middle and last names exist in 
        /// the same field delimited by spaces.  Only one
        /// placeholder is automatically the last name.  Two
        /// placeholders the first is the first name and the 
        /// second the last name.  Two or more those between
        /// the first and last are considered middle names.
        ///
        /// The name is optional.
        /// </summary>
        public readonly string name;

        public User (string email, long created, string name) {
            this.email = email;
            this.created = created;
            this.name = name;
        }
    }
}