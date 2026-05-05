namespace CovarianceAndContravariance.Covariance;

public interface IReadOnlyRepository<out T>
{
    T GetById(int id);
    IEnumerable<T> GetAll();

    // void Save(T entity);
}


// Why does the compiler stop you?
//     The compiler isn't just being stubborn; it is preventing a catastrophic type-safety crash. To understand why, let's look at the disaster that would happen if the compiler did allow this.
//
//     Imagine you have our two classes from earlier: Entity (the base) and User (the derived class, which has a Username property).
//
// If the compiler allowed a Save method on a covariant interface, you could write this perfectly legal-looking code:
//
// C#
// // 1. You create a repository meant specifically for Users.
// // This underlying repository expects that everything it saves will have a "Username".
// IReadRepository<User> specificUserRepo = new UserRepository();
//
// // 2. Because the interface is covariant (out), the compiler lets you assign 
// // the User repository to an Entity repository variable.
// IReadRepository<Entity> genericEntityRepo = specificUserRepo; 
//
// // 3. THE CRASH
// // You call Save() on the generic repository, passing in a generic Entity.
// genericEntityRepo.Save(new Entity { Id = 5 }); 
// The Nightmare Scenario: Look at Step 3. You just passed a plain Entity into an underlying UserRepository. The UserRepository's internal code is going to try to read the Username property to save it to the database—but a plain Entity doesn't have a Username!
//
//     At best, you get a NullReferenceException. At worst, you silently corrupt your database.
//
//     By enforcing the out and in keywords strictly, C# guarantees that if your code compiles, it is logically impossible to accidentally pass the wrong type down the inheritance chain. If an interface needs to do both, it must be invariant (no in or out), which forces you to use the exact matching type every time.