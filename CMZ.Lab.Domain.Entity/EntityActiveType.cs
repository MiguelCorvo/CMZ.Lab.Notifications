using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMZ.Lab.Domain.Entity
{
    [Table("EntityActivityTypes_TM", Schema ="GP")]
    public class EntityActivityType
    {
        /// <summary>
        /// Gets or sets the type of the identifier entity activity.
        /// </summary>
        /// <value>
        /// The type of the identifier entity activity.
        /// </value>
        [Key]
        public short IdEntityActivityType { get; set; }

        /// <summary>
        /// Gets or sets the identifier entity.
        /// </summary>
        /// <value>
        /// The identifier entity.
        /// </value>
        public short IdEntity { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the subscriptions.
        /// </summary>
        /// <value>
        /// The subscriptions.
        /// </value>
        public List<Subscription> Subscriptions { get; set; }
    }
}
