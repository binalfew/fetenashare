using System;
using System.Threading.Tasks;
using Fetenashare.Catalog.Domain.Aggregates.SubjectAggregate;
using Fetenashare.Kernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fetenashare.Catalog.Persistence.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly CatalogContext _context;

        public SubjectRepository(CatalogContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Subject Add(Subject subject)
        {
            return _context.Subjects.Add(subject).Entity;
        }

        public void Update(Subject subject)
        {
            _context.Entry(subject).State = EntityState.Modified;
        }

        public async Task<Subject> GetSubjectAsync(Guid subjectId)
        {
            return await _context.Subjects.FindAsync(subjectId);
        }
    }
}
