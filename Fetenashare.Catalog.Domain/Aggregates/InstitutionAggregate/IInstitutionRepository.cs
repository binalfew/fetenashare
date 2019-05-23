using System;
using System.Threading.Tasks;
using Fetenashare.Kernel.Interfaces;

namespace Fetenashare.Catalog.Domain.Aggregates.InstitutionAggregate
{
    public interface IInstitutionRepository : IRepository<Institution>
    {
        Institution Add(Institution institution);

        void Update(Institution institution);

        Task<Institution> GetInstitutionAsync(Guid institutionId);
    }
}
