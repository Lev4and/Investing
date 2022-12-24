namespace Investing.Core.Domain
{
    public abstract class EntityBase
    {
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set 
            { 
                _id = value;

                OnIdChanged?.Invoke(_id);
            }
        }

        public event Action<Guid> OnIdChanged;
    }
}
