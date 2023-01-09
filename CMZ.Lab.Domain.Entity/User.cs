using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMZ.Lab.Domain.Entity
{
    /// <summary>
    /// Entity for User
    /// </summary>
    [Table("Users", Schema ="Auth")]
    public class User
    {
        /// <summary>
        /// Clave Primaria
        /// </summary>
        [Key]
        public int IdUser { get; set; }

        /// <summary>
        /// Dirección de Email. Debería coincidir con la dirección de Email del contacto relacionado por idContacto
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Indica si el usuario está o no activo. Útil para borrado lógico. Si se cambia a 0 automáticamente debería invalidar cualquier login del usuario.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets the subscriptions.
        /// </summary>
        /// <value>
        /// The subscriptions.
        /// </value>
        public List<Subscription> Subscriptions { get; set; }                
    }
}
