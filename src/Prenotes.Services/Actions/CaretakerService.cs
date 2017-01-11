
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
        
        public Caretaker Create(Caretaker obj, Employee creator)
        {
            using (ISession session = driver.Session()) {
                Caretaker next = CaretakerStore.Create(obj, creator)(session);
                return next;
            }
        }
    }
}