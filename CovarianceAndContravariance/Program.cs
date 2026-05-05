using CovarianceAndContravariance;
using CovarianceAndContravariance.Covariance;


var employeesWriteOnlyRepository = new WriteOnlyRepository<Employee>();
var employeesReadOnlyRepository = new ReadOnlyRepository<Employee>();


AddEmployees(employeesWriteOnlyRepository);
ReadAndPrintRepository(employeesReadOnlyRepository);

static void ReadAndPrintRepository(IReadOnlyRepository<Person> readOnlyRepository)
{
    // readOnlyRepository.Save(new Person("Karen")); //save a Person but at runtime you will get an Employee that has a Name prop
                                                     // and internally the DB save could end up in a NullReferenceException


    readOnlyRepository
        .GetAll()
        .ToList()
        .ForEach(Console.WriteLine);
}

static void AddEmployees(IWriteOnlyRepository<Employee> writeOnlyRepository)
    => new List<Employee>
    {
        new RemoteEmployee("Karen", "Usa"),
        new Employee("Karen")
    }.ForEach(writeOnlyRepository.Save);


record Person(string Name);

record Employee(string Name) : Person(Name);

record RemoteEmployee(string Name, string location) : Employee(Name);


class WriteOnlyRepository<T> : IWriteOnlyRepository<T>
{
    public void Save(T item)
    {
        throw new NotImplementedException();
    }

    public void Delete(T item)
    {
        throw new NotImplementedException();
    }
}

class ReadOnlyRepository<T> : IReadOnlyRepository<T>
{
    public T GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Save(T entity)
    {
        throw new NotImplementedException();
    }
}