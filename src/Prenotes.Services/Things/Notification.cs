

namespace Prenotes.Services.Things
{
    public class Notification {
        
        /// <summary>
        /// Twitter limits a tweat to 140 characters which seems like
        /// a decent limit even for Prenotes
        /// </summary>
        public readonly string message;

        /// <summary>
        /// When the notification was created
        /// </summary>
        public readonly long created;

        /// <summary>
        /// Tweat's language (if none specified then system default)
        /// </summary>
        public readonly string lang;

        // TODO: Maybe we can get more ideas about characteristics for 
        //       notifications by looking at the Twitter Tweat API
        //       https://dev.twitter.com/overview/api/tweets
        //       However, at lot of things can be represented as relationships!

        public Notification(string message, long created, string lang) {
            this.message = message;
            this.created = created;
            this.lang = lang;
        }
    }
}