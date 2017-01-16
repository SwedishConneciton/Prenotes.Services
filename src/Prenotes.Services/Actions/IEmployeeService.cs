

using Prenotes.Services.Things;

namespace Prenotes.Services.Actions {

    public interface IEmployeeService {


        /// <summary>
        /// Signup a caretaker for a child at a daycare
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="daycare"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        int SignupCaretaker(Caretaker obj, Employee employee, Daycare daycare, Child child);
    }
}