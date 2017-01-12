
namespace Prenotes.Services.Things {

    public class Caretaker : User {

        /// <remark>
        /// The constructor extends the abstract class's constructor using 
        /// the ": base(...)" directive.  It just passes arguments to the 
        /// User's constructor letting a Caretaker instance use the public 
        /// properties defined in User (i.e. email, created, name).
        ///
        /// https://msdn.microsoft.com/en-us/library/hfw7t1ce.aspx
        /// </remark>
        /// <param name="email"></param>
        /// <param name="created"></param>
        /// <param name="name"></param>
        public Caretaker(string email, long created, string name): base(email, created, name) {
        }
    }
}