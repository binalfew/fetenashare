using System;

namespace Fetenashare.Kernel.Extensions
{
    public static class ResultExtensions
    {
        public static Result<T> ToResult<T>(this Maybe<T> maybe, string errorMessage) where T : class =>
            maybe.HasNoValue ? Result.Fail<T>(errorMessage) : Result.Ok(maybe.Value);

        public static Result OnSuccess(this Result result, Action action)
        {
            if (result.IsFailure) return result;

            action();

            return Result.Ok();
        }

        public static Result OnSuccess(this Result result, Func<Result> func) =>
            result.IsFailure ? result : func();

        public static Result<T> OnSuccess<T>(this Result<T> result, Action<T> action)
        {
            if (result.IsSuccess)
            {
                action(result.Value);
            }

            return result;
        }

        public static Result<TK> OnSuccess<T, TK>(this Result<T> result, Func<T, TK> func) =>
            result.IsFailure ? Result.Fail<TK>(result.Message) : Result.Ok(func(result.Value));

        public static Result OnFailure(this Result result, Action action)
        {
            if (result.IsFailure) action();

            return result;
        }

        public static Result OnBoth(this Result result, Action<Result> action)
        {
            action(result);

            return result;
        }

        public static T OnBoth<T>(this Result result, Func<Result, T> func) => func(result);

        public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, string errorMessage)
        {
            if (result.IsFailure) return result;

            return !predicate(result.Value) ? Result.Fail<T>(errorMessage) : result;
        }

        public static Result<TK> Map<T, TK>(this Result<T> result, Func<T, TK> func) =>
            result.IsFailure ? Result.Fail<TK>(result.Message) : Result.Ok(func(result.Value));
    }
}