namespace CMZ.Lab.Application.DTO
{
    /// <summary>
    /// DTO for Create Subscription
    /// </summary>
    public class CreateSubscriptionDTO
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
        public short IdNotificationFrequency { get; set; }

        /// <summary>
        /// Gets or sets the type of the name activity.
        /// </summary>
        /// <value>
        /// The type of the name activity.
        /// </value>
        public int? IdEntityObject { get; set;  }

        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public bool NotifyByEmail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CreateSubscriptionDTO"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the identifier entity.
        /// </summary>
        /// <value>
        /// The identifier entity.
        /// </value>
        public short IdEntity { get; set; }
    }
}
