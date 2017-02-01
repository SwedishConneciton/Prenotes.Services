
using Neo4j.Driver.V1;
using Prenotes.Services.Actions;
using Prenotes.Services.Validation;

namespace Prenotes.Services.Builders {

    public static class ServiceBuilder {

        public static ICaretakerService CaretakerService(string url, string user, string password) {

            var driver = GraphDatabase.Driver(
                url, 
                AuthTokens.Basic(user, password)
            );

            return new CaretakerValidator(
                new CaretakerService(driver)
            );
        }
    }
}
