
using System;
using System.Collections.Generic;
using Neo4j.Driver.V1;
using Prenotes.Services.Things;

namespace Prenotes.Services.Stores {

    public static class CaretakerStore {

        public static Func<IDriver, Caretaker> Create(Caretaker obj) {
            return (IDriver d) => {
                using (var session = d.Session()) {
                    var results = session
                        .Run(
                            "CREATE (a:Caretaker {email: {email})",
                            new Dictionary<string, object> { {"email", obj.email} }
                        );
                }

                return obj;
            };
        }
    }
}