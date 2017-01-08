
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
        
        public Caretaker Create(Caretaker obj)
        {
            Caretaker next = CaretakerStore.Create(obj)(driver);
            return next;
        }
    }
}