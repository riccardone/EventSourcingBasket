namespace Domain.Services
{
    // inspired by https://eventuallyconsistent.net/tag/pipe-and-filters/
    public interface IFilter<in T>
    {
        void Execute(T msg);
    }
}
