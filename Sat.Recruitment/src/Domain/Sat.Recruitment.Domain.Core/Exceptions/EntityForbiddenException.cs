using System;

namespace Sat.Recruitment.Domain.Core.Exceptions
{
    public class EntityForbiddenException : Exception
    {
        public Type EntityType { get; private set; }
        public string EntityId { get; private set; }

        public EntityForbiddenException(Type type, string id) : base($"{type.Name} with Id: '{id}' - Forbidden")
        {
            EntityType = type ?? throw new ArgumentNullException(nameof(type));
            EntityId = id ?? throw new ArgumentNullException(nameof(id));
        }

        public EntityForbiddenException(Type type) : base($"{type.Name} - Forbidden")
        {
            EntityType = type ?? throw new ArgumentNullException(nameof(type));           
        }
    }
}
