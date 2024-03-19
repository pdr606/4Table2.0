namespace _4Tables2._0.Domain.Base.Common
{
    public class Result
    {
        public bool Succeeded { get; init; }
        public string[] Errors { get; init; }

        internal Result(bool succeeded, IEnumerable<string> erros)
        {
            Succeeded = succeeded;
            Errors = erros.ToArray();
        }

        public static Result Success()
        {
            return new Result(true, Array.Empty<string>());
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false, errors);
        }
    }
}
