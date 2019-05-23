using System;
using System.Threading.Tasks;
using Fetenashare.Catalog.Domain.Aggregates.QuestionTypeAggregate;
using Fetenashare.Kernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fetenashare.Catalog.Persistence.Repositories
{
    public class QuestionTypeRepository : IQuestionTypeRepository
    {
        private readonly CatalogContext _context;

        public QuestionTypeRepository(CatalogContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public QuestionType Add(QuestionType questionType)
        {
            return _context.QuestionTypes.Add(questionType).Entity;
        }

        public void Update(QuestionType questionType)
        {
            _context.Entry(questionType).State = EntityState.Modified;
        }

        public async Task<QuestionType> GetQuestionTypeAsync(Guid questionTypeId)
        {
            return await _context.QuestionTypes.FindAsync(questionTypeId);
        }
    }
}
