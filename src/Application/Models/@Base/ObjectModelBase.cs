using Domain.Models.Base;

namespace Application.Models.Base
{
    public abstract class ObjectModelBase
    {
    }

    public abstract class ObjectModelBase<T> : ObjectModelBase
        where T : ModelBase
    {
        public abstract void AssignFrom(T entity);
    }
}