using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMZ.Lab.Domain.Entity
{
    [Table("NotificationsFrequencies_TM", Schema = "GP")]
    public class NotificationFrecuencie
    {
        /// <summary>
        /// ID único para cada frecuencia de notificación
        /// </summary>
        [Key]
        public short IdNotificationFrequency { get; set; }

        /// <summary>
        /// Name de cada tipo de actividad
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descripción detallada de cada tipo de actividad
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Este campo se utiliza como &quot;borrado lógico&quot;. Indica los valores que aún se pueden seleccionar.
        /// </summary>
        public bool Selectable { get; set; }

        /// <summary>
        /// Este valor se utiliza para ordenar los elementos de una manera específica. ORDER By ListOrder ASC, Name ASC
        /// </summary>
        public short ListOrder { get; set; }

        /// <summary>
        /// Date en la que se dio de alta el registro
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// User que dio de alta el registro
        /// </summary>
        public string UserCreation { get; set; }

        /// <summary>
        /// Date en la que se modificó el registro
        /// </summary>
        public DateTime? DateModification { get; set; }

        /// <summary>
        /// User que modificó el registro
        /// </summary>
        public string UserModification { get; set; }

        /// <summary>
        /// Gets or sets the subscriptions.
        /// </summary>
        /// <value>
        /// The subscriptions.
        /// </value>
        public List<Subscription> Subscriptions { get; set; }
    }
}
