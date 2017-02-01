
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
        
        public Caretaker Confirm(String email, string code)
        {
            using (ISession session = driver.Session()) {
                Caretaker next = CaretakerStore.Confirm(email, code)(session);
                return next;
            }
        }

        void ICaretakerService.Nuke(string email)
        {
            throw new NotImplementedException();
        }

        Caretaker ICaretakerService.Edit(Caretaker obj)
        {
            throw new NotImplementedException();
        }

        Notification ICaretakerService.Notify(string email, string message, Child[] children)
        {
            throw new NotImplementedException();
        }

        Notification ICaretakerService.Reply(string email, string message, string whoami) 
        {
            throw new NotImplementedException();
        }

        Notification ICaretakerService.Retract(string email, string whoami)
        {
            throw new NotImplementedException();
        }

        Notification[] ICaretakerService.Stream(string email, int skip, int take)
        {
            throw new NotImplementedException();
        }

        Notification ICaretakerService.Read(string email, string whoami) 
        {
            throw new NotImplementedException();
        }

        Child[] ICaretakerService.Children(string email)
        {
            throw new NotImplementedException();
        }
    }
}