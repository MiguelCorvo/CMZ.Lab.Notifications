using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CMZ.Lab.Domain.Entity
{
    [Table("Notifications", Schema ="GP")]
    public class Notification
    {
        /// <summary>
        /// Clave primaria de la notificación
        /// </summary>
        [Key]
        public int IdNotifications { get; set; }

        /// <summary>
        /// Id de la subscripción a la que pertenece la notificación
        /// </summary>
        public int IdSubscription { get; set; }

        /// <summary>
        /// Establece si la notificación ha sido leída
        /// </summary>
        public bool Read { get; set; }

        /// <summary>
        /// Message presentado como notificación
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Establece si la notificación ha sido vista
        /// </summary>
        public bool Viewed { get; set; }

        /// <summary>
        /// Indíca si la notificación aparecerá en la categoría urgente o no
        /// </summary>
        public bool Urgent { get; set; }

        /// <summary>
        /// Date en la que se añadio la notificación
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// User que realizó el evento registrado
        /// </summary>
        public string UserCreation { get; set; }

        /// <summary>
        /// Nabegacion Subscripcion
        /// </summary>
        /// <value>
        /// The identifier subscription navigation.
        /// </value>
        public virtual Subscription IdSubscriptionNavigation { get; set; }

    }
}
