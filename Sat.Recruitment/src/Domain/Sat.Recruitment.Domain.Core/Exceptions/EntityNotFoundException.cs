using System;

namespace Sat.Recruitment.Domain.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public Type EntityType { get; private set; }
        public string EntityId { get; private set; }

        public EntityNotFoundException(Type type, string id) : base($"{type.Name} with Id: '{id}' not found")
        {
            EntityType = type ?? throw new ArgumentNullException(nameof(type));
            EntityId = id ?? throw new ArgumentNullException(nameof(id));
        }

        public EntityNotFoundException(Type type) : base($"{type.Name} not found")
        {
            EntityType = type ?? throw new ArgumentNullException(nameof(type));           
        }
    }
}
