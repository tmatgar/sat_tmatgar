using System;

namespace Sat.Recruitment.Domain.Core.Exceptions
{
    public class EntityCollectionEmptyException : Exception
    {
        public Type EntityType { get; private set; }

        public EntityCollectionEmptyException(Type type) : base($"Entity collection of '{type.Name}' is empty")
        {
            EntityType = type ?? throw new ArgumentNullException(nameof(type));
        }
    }
}
