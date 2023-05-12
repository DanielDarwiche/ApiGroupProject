using Library;
using Microsoft.EntityFrameworkCore;

namespace ApiGroupProject.Services
{
    public class TimeReportRepo : ITimeReportRepository
    {
        private WarriorContext _context;

        public TimeReportRepo(WarriorContext db)
        {
            _context = db;
        }
        public async Task<TimeReport> AddTimeReport(TimeReport tr)
        {
            var timeAdd = await _context.TimeReports.AddAsync(tr);
            await _context.SaveChangesAsync();
            return timeAdd.Entity;

        }

        public async Task<TimeReport> DeleteTimeReport(int id)
        {
            //Finding object to delete
            var TtoDel = await _context.TimeReports.FirstOrDefaultAsync(x => x.TimeReportId == id);
            //if obj is found
            if (TtoDel != null)
            {
                //deleted from database and saved
                _context.TimeReports.Remove(TtoDel);
                await _context.SaveChangesAsync();
                return TtoDel;
            }
            //else, returning null
            return null;
        }
        public async Task<IEnumerable<TimeReport>> GetAll()
        {
            //getting all objects in database
            return await _context.TimeReports.ToListAsync();
        }

        public async Task<TimeReport> UpdateTimeReport(int id, TimeReport tr)
        {
            var identified = await _context.TimeReports.FirstOrDefaultAsync(e => e.TimeReportId == tr.TimeReportId);
            if (identified != null)
            {
                identified.Week = tr.Week;
                identified.Hours = tr.Hours;
                await _context.SaveChangesAsync();
                return identified;
            }
            return null;
        }


        public async Task<TimeReport> GetSingle(int id)
        {
            //identifying object
            var identi = await _context.TimeReports.FirstOrDefaultAsync(x => x.TimeReportId == id);
            if (identi != null)
            {//if object is identified, return object, else return null
                return identi;
            }
            return null;
        }
    }
}


