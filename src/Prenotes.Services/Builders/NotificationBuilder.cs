

using System.Collections.Generic;
using Prenotes.Services.Things;

namespace Prenotes.Services.Builders {

    public class NotificationBuilder {

        /// <summary>
        /// Property bucket for the underlying Notification
        /// </summary>
        private Dictionary<string, object> fields = new Dictionary<string, object>();

        public NotificationBuilder() {

        }
        
        public NotificationBuilder Language(string lang) {
            fields["language"] = lang;
            return this;
        }

        public Notification Build(string message) {
            return new Notification(
                Utils.WhoAmI(),
                message,
                Utils.Epoch(),
                fields.ContainsKey("language") ? (string)fields["language"] : null
            );
        }
    }
}