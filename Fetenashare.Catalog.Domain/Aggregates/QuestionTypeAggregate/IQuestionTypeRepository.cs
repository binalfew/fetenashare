using System;
using System.Threading.Tasks;
using Fetenashare.Kernel.Interfaces;

namespace Fetenashare.Catalog.Domain.Aggregates.QuestionTypeAggregate
{
    public interface IQuestionTypeRepository : IRepository<QuestionType>
    {
        QuestionType Add(QuestionType questionType);

        void Update(QuestionType questionType);

        Task<QuestionType> GetQuestionTypeAsync(Guid questionTypeId);
    }
}
