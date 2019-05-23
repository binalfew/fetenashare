using System;
using System.Threading.Tasks;
using Fetenashare.Kernel.Interfaces;

namespace Fetenashare.Catalog.Domain.Aggregates.SubjectAggregate
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        Subject Add(Subject subject);

        void Update(Subject subject);

        Task<Subject> GetSubjectAsync(Guid subjectId);
    }
}
