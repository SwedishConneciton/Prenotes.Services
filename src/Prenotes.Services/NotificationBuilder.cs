

using System.Collections.Generic;
using Prenotes.Services.Things;

namespace Prenotes.Services {

    public class NotificationBuilder {

        /// <summary>
        /// Property bucket for the underlying Notification
        /// </summary>
        private Dictionary<string, object> fields = new Dictionary<string, object>();

        public NotificationBuilder() {

        }
        
        public NotificationBuilder WithLanguage(string lang) {
            fields["language"] = lang;
            return this;
        }

        public Notification Build(string message) {
            long created = new System.DateTimeOffset().ToUnixTimeSeconds();

            return new Notification(
                Utils.WhoAmI(),
                message,
                created,
                (string)fields["language"]
            );
        }
    }
}