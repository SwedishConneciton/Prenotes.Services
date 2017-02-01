
using System;
using System.Collections.Generic;
using System.Linq;
using Neo4j.Driver.V1;
using Prenotes.Services.Exceptions;
using Prenotes.Services.Logging;
using Prenotes.Services.Things;

namespace Prenotes.Services.Stores {

    public static class CaretakerStore {

        /// <summary>
        /// Confirmation results the creation of the Caretaker: 
        ///    1) Match Handshake with any CONFIRMED relationship, Employee that 
        ///       created the handshake and Child(ren) associated to the 
        ///       handshake using the code parameter and the Caretaker's email
        ///    2) Create Caretaker, REGISTERED from Employee and HAS 
        ///       to CHILD (instances)
        ///    3) Set Handshake.confirmed to creation time
        /// </summary>
        /// <param name="email"></param>
        /// <param name="code"></param>
        /// <returns>(ISession) => Caretaker</returns>
        /// <exception cref="DuplicateException">Caretaker email not unique</exception>
        public static Func<ISession, Caretaker> Confirm(string email, string code) {
            return (ISession session) => {
                int created = Utils.Epoch();

                try {
                    using (var tx = session.BeginTransaction()) {
                    var results = tx
                        .Run(
                            "MATCH (h:Handshake {code: {code}, email: {email}})<-[:CREATED]-(e:Employee) WHERE not ((h)<-[:CONFIRMED]-(:Caretaker)) " +
                            "CREATE (c:User:Caretaker {email: {email}, created: {created}})<-[:REGISTERED]-(e) " +
                            "WITH h, e, c " +
                            "MATCH (h)-[:WITH]->(k:Child) " +
                            "CREATE (c)-[:HAS]->(k) " +
                            "SET h.confirmed = {created} " +
                            "RETURN c as caretaker, collect(k) as children",
                            new Dictionary<string, object> {
                                {"code", code},
                                {"email", email},
                                {"created", created }
                            }
                        );
                    
                    Caretaker next = results
                        .ToList()
                        .First()
                        .ToCaretaker();
                        
                    tx.Success();

                    Log.ConfirmCaretaker(
                        next.email, 
                        next.children?.Count() ?? 0
                    );

                        return next;
                    }
                } catch (ClientException e) {
                    throw new SystemException(e.Message);
                }
            };
        }
    }
}