using Library;

namespace ApiGroupProject.Services
{
    public interface IProjectRepository
    {
        Task<Project> AddProject(Project project);// C
        Task<IEnumerable<Project>> GetAll();// R
        Task<Project> GetSingle(int id);
        Task<Project> UpdateProject(int id, Project pro);// U
        Task<Project> DeleteProject(int id);// D

    }
}
