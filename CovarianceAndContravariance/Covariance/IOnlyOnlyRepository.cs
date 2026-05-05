// This is INVARIANT. You cannot use 'in' or 'out' here.

namespace CovarianceAndContravariance.Covariance;

public interface IOnlyOnlyRepository<T> : IReadOnlyRepository<T>, IWriteOnlyRepository<T>
{
    // T GetById(int id); // T is an output
    // void Save(T item); // T is an input
}

//
// Because T flows in both directions (as a parameter and as a return type), C# locks it down. IRepository<User> and IRepository<Entity> have no relationship to each other.
//
//  To use variance, you must segregate your interfaces into read-only and write-only operations (which aligns perfectly with patterns like CQRS).