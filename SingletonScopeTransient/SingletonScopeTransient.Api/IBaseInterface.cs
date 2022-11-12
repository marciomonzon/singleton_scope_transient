namespace SingletonScopeTransient.Api
{
    public interface IBaseInterface
    {
        public Guid Value {get;}
    }

    public interface ISingleton : IBaseInterface
    {

    }

    public interface IScoped : IBaseInterface
    {
        
    }

    public interface ITransient : IBaseInterface
    {
        
    }


    public class ImplementationClass : ISingleton, IScoped, ITransient
    {
        public Guid Value {get;}

        public ImplementationClass()
        {
            Value = Guid.NewGuid();
        }
    }
}