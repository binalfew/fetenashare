using System;
using System.Threading.Tasks;
using Fetenashare.Catalog.Domain.Aggregates.InstitutionAggregate;
using Fetenashare.Kernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fetenashare.Catalog.Persistence.Repositories
{
    public class InstitutionRepository : IInstitutionRepository
    {
        private readonly CatalogContext _context;

        public InstitutionRepository(CatalogContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Institution Add(Institution institution)
        {
            return _context.Institutions.Add(institution).Entity;
        }

        public void Update(Institution institution)
        {
            _context.Entry(institution).State = EntityState.Modified;
        }

        public async Task<Institution> GetInstitutionAsync(Guid institutionId)
        {
            return await _context.Institutions.FindAsync(institutionId);
        }
    }
}
