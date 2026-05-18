namespace EmployeeManagement.Utility.Responses;

public class Envelope<T> : BaseResponse
{
    public T? Data { get; set; }
}