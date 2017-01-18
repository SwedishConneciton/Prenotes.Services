
namespace Prenotes.Services.Things {

    public class Caretaker : User {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="created"></param>
        /// <param name="name"></param>
        public Caretaker(string email, long created, string name): base(email, created, name) {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        // TODO: Made an additional constructor which is useful when 
        //       confirming a caretaker.  Look at the constructor for 
        //       the abstract User class to see what default values 
        //       are used (i.e. what "created" and "name" are set to)
        public Caretaker(string email): base(email) {

        }
    }
}