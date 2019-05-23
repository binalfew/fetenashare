using System;
using System.Threading.Tasks;
using Fetenashare.Catalog.Domain.Aggregates.QuestionAggregate;
using Fetenashare.Kernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fetenashare.Catalog.Persistence.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly CatalogContext _context;

        public QuestionRepository(CatalogContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Question Add(Question question)
        {
            return _context.Questions.Add(question).Entity;
        }

        public void Update(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
        }

        public async Task<Question> GetQuestionAsync(Guid questionId)
        {
            return await _context.Questions.FindAsync(questionId);
        }
    }
}
