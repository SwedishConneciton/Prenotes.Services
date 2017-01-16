
using Neo4j.Driver.V1;
using Prenotes.Services.Stores;
using Prenotes.Services.Things;

namespace Prenotes.Services.Actions {

    public class CaretakerService : ICaretakerService
    {
        private readonly IDriver driver;

        public CaretakerService (IDriver driver) {
            this.driver = driver;
        }
        
        public Caretaker Confirm(Caretaker obj, int code)
        {
            using (ISession session = driver.Session()) {
                Caretaker next = CaretakerStore.Confirm(obj, code)(session);
                return next;
            }
        }
    }
}