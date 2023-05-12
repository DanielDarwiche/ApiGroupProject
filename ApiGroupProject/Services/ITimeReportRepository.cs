using Library;

namespace ApiGroupProject.Services
{
    public interface ITimeReportRepository
    {
        Task<TimeReport> AddTimeReport(TimeReport timeReport);// C
        Task<IEnumerable<TimeReport>> GetAll();// R
        Task<TimeReport> GetSingle(int id);
        Task<TimeReport> UpdateTimeReport(int id, TimeReport tr);// U
        Task<TimeReport> DeleteTimeReport(int id);// D
    }
}
