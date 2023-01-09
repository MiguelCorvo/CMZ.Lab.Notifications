namespace CMZ.Lab.Application.DTO
{
    /// <summary>
    /// DTO for Subscription
    /// </summary>
    public class SubscriptionDTO
    {
        /// <summary>
        /// Gets or sets the identifier subscription.
        /// </summary>
        /// <value>
        /// The identifier subscription.
        /// </value>
        public int IdSubscription { get; set; }

        /// <summary>
        /// Gets or sets the name frecuency.
        /// </summary>
        /// <value>
        /// The name frecuency.
        /// </value>
        public string NameFrecuency { get; set; }

        /// <summary>
        /// Gets or sets the type of the name activity.
        /// </summary>
        /// <value>
        /// The type of the name activity.
        /// </value>
        public string NameActivityType { get; set; }

        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Establece de si debe notificar por email mediante la subscripción
        /// </summary>
        public bool NotifyByEmail { get; set; }
    }
}
