using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMZ.Lab.Domain.Entity
{
    [Table("Subscriptions", Schema ="GP")]
    public class Subscription
    {
        /// <summary>
        /// Tabla que almacena la suscripción que cada usuario tiene a cada entidad, y de qué tipo. Estar suscrito significa que el usuario quiere &quot;seguir&quot; ciertos cambios de una entidad específica y EntityID
        /// </summary>
        [Key]
        public int IdSubscription { get; set; }

        /// <summary>
        /// PK del usuario suscrito
        /// </summary>
        public int IdUser { get; set; }

        /// <summary>
        /// ID único para cada frecuencia de notificación
        /// </summary>
        public short IdNotificationFrequency { get; set; }

        /// <summary>
        /// Clave primaria de la Entity gestionable desde hub.cmz.com
        /// </summary>
        public short IdEntity { get; set; }

        /// <summary>
        /// ID de la entidad almacenada en &quot;IdEntity&quot;
        /// </summary>
        public int? IdEntityObject { get; set; }

        /// <summary>
        /// ID único para cada tipo de actividad, a la que el usuario está suscrito
        /// </summary>
        public short IdEntityActivityType { get; set; }

        /// <summary>
        /// Establece de si debe notificar por email mediante la subscripción
        /// </summary>
        public bool NotifyByEmail { get; set; }

        /// <summary>
        /// Establece si la subscripción está activa o no. Si la sub no está activa guardará la configuración anterior pero no se tendrá en cuenta para notificar.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Date en la que se dio de alta el registro
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// User que dio de alta el registro
        /// </summary>
        public string UserCreation { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the notification frecuencie.
        /// </summary>
        /// <value>
        /// The notification frecuencie.
        /// </value>
        public NotificationFrecuencie NotificationFrecuencie { get; set; }

        /// <summary>
        /// Gets or sets the type of the entity activity.
        /// </summary>
        /// <value>
        /// The type of the entity activity.
        /// </value>
        public EntityActivityType EntityActivityType { get; set; }
            
        /// <summary>
        /// Gets or sets the notifications.
        /// </summary>
        /// <value>
        /// The notifications.
        /// </value>
        public List<Notification> Notifications { get; set; }
    }
}
