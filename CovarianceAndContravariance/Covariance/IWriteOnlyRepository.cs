// The 'in' keyword makes this interface contravariant.
// T can only be used as a method parameter, never as a return type.
namespace CovarianceAndContravariance;

public interface IWriteOnlyRepository<in T>
{
    void Save(T item);
    void Delete(T item);
}