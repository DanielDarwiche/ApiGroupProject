using Library;
using Microsoft.EntityFrameworkCore;

namespace ApiGroupProject.Services
{
    public class EmployeeRepo : IEmployeeRepository
    {
        private WarriorContext _context;

        public EmployeeRepo(WarriorContext db)
        {
            _context = db;
        }
        public async Task<Employee> AddEmployee(Employee emp)
        {
            var newE = await _context.Employees.AddAsync(emp);
            if (newE != null)
            {
                await _context.SaveChangesAsync();
                return newE.Entity;
            }
            return null;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var empDel = await _context.Employees.FirstOrDefaultAsync(emp => emp.EmployeeId == id);
            if (empDel != null)
            {
                _context.Employees.Remove(empDel);
                await _context.SaveChangesAsync();
                return empDel;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllEmployeesByProject(int id)
        {
            //2Vi vill kunna få ut en lista på alla anställda som jobba med ett specifikt projekt
            var query = await (from pro in _context.Projects
                               join emps in _context.Employees on pro.ProjectId equals emps.ProjectId
                               where pro.ProjectId == id
                               select emps.EmployeeName).ToListAsync();
            if (query != null)
            {
                return query;
            }
            return null;

        }

        public async Task<TimeReport> GetHoursWorked(int id, int week)
        {
            var timeReport = await _context.TimeReports
            .FirstOrDefaultAsync(tr => tr.EmployeeId == id && tr.Week == week);
            return timeReport;
        }

        public async Task<IEnumerable<TimeReport>> GetTimeReportsOfEmployee(int ID)
        {
            var query = await (from emp in _context.Employees
                               join tim in _context.TimeReports on emp.EmployeeId equals tim.EmployeeId
                               where emp.EmployeeId == ID
                               select tim).ToListAsync();
            if (query.Count() == 0)
            {
                return null;
            }

            if (query != null)
            {
                return query;
            }
            return null;
        }

        public async Task<Employee> UpdateEmployee(int id, Employee emp)
        {
            var identified = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (identified != null)
            {
                identified.EmployeeName = emp.EmployeeName;

                await _context.SaveChangesAsync();
                return identified;
            }
            return null;
        }

    }
}