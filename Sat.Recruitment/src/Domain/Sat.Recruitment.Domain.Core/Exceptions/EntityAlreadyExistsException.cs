using System;

namespace Sat.Recruitment.Domain.Core.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public Type EntityType { get; private set; }
        public string EntityId { get; private set; }

        public EntityAlreadyExistsException(Type type, string id) : base($"{type.Name} '{id}' is duplicated")
        {
            EntityType = type ?? throw new ArgumentNullException(nameof(type));
            EntityId = id ?? throw new ArgumentNullException(nameof(id));
        }
    }
}
