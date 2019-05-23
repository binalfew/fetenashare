using System;
using System.Threading.Tasks;

namespace Fetenashare.Catalog.Domain.Aggregates.QuestionAggregate
{
    public interface IQuestionRepository
    {
        Question Add(Question question);

        void Update(Question question);

        Task<Question> GetQuestionAsync(Guid questionId);
    }
}
