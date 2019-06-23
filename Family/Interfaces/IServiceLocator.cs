namespace Family.Interfaces
{
    public interface IServiceLocator
    {
        T GetService<T>();
    }
}
