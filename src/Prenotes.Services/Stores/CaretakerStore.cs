
using System;
using System.Collections.Generic;
using Neo4j.Driver.V1;
using Prenotes.Services.Exceptions;
using Prenotes.Services.Things;

namespace Prenotes.Services.Stores {

    public static class CaretakerStore {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="creator"></param>
        /// <returns></returns>
        public static Func<ISession, Caretaker> Confirm(Caretaker obj, string code) {
            return (ISession session) => {
                long created = new System.DateTimeOffset().ToUnixTimeSeconds();

                try {
                    var results = session
                        .Run(
                            "MATCH (h:Handshake {code: {code}, email: {email}})<-[:CREATED]-(e:User:Employee) " +
                            "CREATE (c:User:Caretaker {email: {email}, created: {created}, name: {name}})" +
                            "<-[:CREATED]-(e)",
                            new Dictionary<string, object> {
                                {"code", code},
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