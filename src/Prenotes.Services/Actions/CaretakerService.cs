
using System;
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
        
        public Caretaker Confirm(Caretaker obj, string code)
        {
            using (ISession session = driver.Session()) {
                Caretaker next = CaretakerStore.Confirm(obj, code)(session);
                return next;
            }
        }

        void ICaretakerService.Delete(Caretaker obj)
        {
            throw new NotImplementedException();
        }

        void ICaretakerService.Detach(Caretaker obj, Child child)
        {
            throw new NotImplementedException();
        }

        Caretaker ICaretakerService.Edit(Caretaker obj)
        {
            throw new NotImplementedException();
        }

        Notification ICaretakerService.Notify(Notification obj, Child[] children)
        {
            throw new NotImplementedException();
        }

        Notification ICaretakerService.Retrack(Notification obj)
        {
            throw new NotImplementedException();
        }
    }
}