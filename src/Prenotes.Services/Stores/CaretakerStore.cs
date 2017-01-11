
using System;
using System.Collections.Generic;
using Neo4j.Driver.V1;
using Prenotes.Services.Exceptions;
using Prenotes.Services.Things;

namespace Prenotes.Services.Stores {

    public static class CaretakerStore {

        public static Func<ISession, Caretaker> Create(Caretaker obj, Employee creator) {
            return (ISession session) => {
                long created = new System.DateTimeOffset().ToUnixTimeSeconds();

                try {
                    var results = session
                        .Run(
                            "MATCH (e:User:Employee {email: {creator}}) " +
                            "CREATE (c:User:Caretaker {email: {email}, created: {created}, name: {name}})" +
                            "<-[:CREATED]-(e)",
                            new Dictionary<string, object> {
                                {"creator", creator.email}, 
                                {"email", obj.email},
                                {"created", created },
                                {"name", obj.name }
                            }
                        )
                        .Consume();

                    if (results.Counters.NodesCreated > 1) {
                        throw new DuplicateException($"{nameof(obj.email)} {obj.email} not unique for {nameof(obj)}");
                    }

                    return new Caretaker(obj.email, created, obj.name);
                } catch (ClientException e) {
                    throw new SystemException(e.Message);
                }
            };
        }
    }
}