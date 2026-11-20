namespace AddisEats.Api.Common;

public record Error(
    string Code,
    string Message,
    int Status
);

public class Result<T>
{
    public T? Value {get; init;}
    public Error? error{get;init;}
    public bool IsSuccess => error is null;
    public static Result<T> Ok(T Value)=> new () {Value = Value};
    public static Result<T>fail(string Code, string Message, int Status)
    => new()
    {
        error = new Error(Code,Message,Status)
    };

}
