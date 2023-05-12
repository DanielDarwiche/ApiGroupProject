using Library;
using Microsoft.EntityFrameworkCore;

namespace ApiGroupProject.Services
{
    public class ProjectRepo : IProjectRepository
    {
        private WarriorContext _context;

        public ProjectRepo(WarriorContext db)
        {
            _context = db;
        }
        public async Task<Project> AddProject(Project pro)
        {
            var ProjToAdd = await _context.Projects.AddAsync(pro);
            await _context.SaveChangesAsync();
            return ProjToAdd.Entity;
        }
        public async Task<Project> DeleteProject(int id)
        {
            //Finding object to delete
            var objDel = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);
            //if obj is found
            if (objDel != null)
            {
                //deleted from database and saved
                _context.Projects.Remove(objDel);
                await _context.SaveChangesAsync();
                return objDel;
            }
            //else, returning null
            return null;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            //getting all objects in database
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetSingle(int id)
        {
            //identifying object
            var identi = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);
            if (identi != null)
            {//if object is identified, return object, else return null
                return identi;
            }
            return null;
        }

        public async Task<Project> UpdateProject(int id, Project pro)
        {
            var identified = await _context.Projects.FirstOrDefaultAsync(e => e.ProjectId == pro.ProjectId);
            if (identified != null)
            {
                identified.ProjectName = pro.ProjectName;

                await _context.SaveChangesAsync();
                return identified;
            }
            return null;
        }
    }
}
