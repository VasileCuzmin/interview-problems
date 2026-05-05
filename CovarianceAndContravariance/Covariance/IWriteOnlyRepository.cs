// The 'in' keyword makes this interface contravariant.
// T can only be used as a method parameter, never as a return type.
namespace CovarianceAndContravariance.Covariance;

public interface IWriteOnlyRepository<in T>
{
    void Save(T item);
    void Delete(T item);
}