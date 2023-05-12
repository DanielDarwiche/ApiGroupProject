using Library;

namespace ApiGroupProject.Services
{
    public interface IEmployeeRepository
    {

        Task<IEnumerable<TimeReport>> GetTimeReportsOfEmployee(int ID);//1Vi vill kunna hämta ut detaljerad information om en specifik anställd och dennas tidsrapporter 
        Task<IEnumerable<Employee>> GetAll(); // (1) A.  Vi vill kunna få ut en lista med alla anställda i systemet 
        Task<IEnumerable<string>> GetAllEmployeesByProject(int id); //2Vi vill kunna få ut en lista på alla anställda som jobba med ett specifikt projekt
        Task<TimeReport> GetHoursWorked(int id, int week);// 3 Vi vill kunna få ut hur många timmar en specifik anställd jobbat en specifik vecka (ex antal timmar vecka 25)
        Task<Employee> UpdateEmployee(int id, Employee emp);// 4.Vi vill kunna lägga till, uppdatera och ta bort anställda.
        Task<Employee> AddEmployee(Employee emp); //4.Vi vill kunna lägga till, uppdatera och ta bort anställda.
        Task<Employee> DeleteEmployee(int id); //4.Vi vill kunna lägga till, uppdatera och ta bort anställda.
    }
}
