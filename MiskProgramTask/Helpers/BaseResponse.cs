namespace MiskProgramTask.Helpers;

public class BaseResponse
{
    public string Message { get; set; }
    public string? InnerMessage { get; set; }
    public ResponseCode ResponseCode { get; set; }

    public bool IsSuccess
    {
        get { return ResponseCode == ResponseCode.Success; }
    }

    public BaseResponse(ResponseCode responseCode = ResponseCode.Success, string message = "")
    {
        ResponseCode = responseCode;
        Message = message;
    }
}

public class BaseResponse<T> : BaseResponse
{
    public T Data { get; set; }


    public BaseResponse(ResponseCode responseCode = ResponseCode.Success, string message = "")
        : base(responseCode, message)
    {
    }

    public BaseResponse(T data, ResponseCode responseCode = ResponseCode.Success, string message = "")
        : base(responseCode, message)
    {
        Data = data;
    }

    public static BaseResponse<T> Error(T data, Exception ex)
    {
        var res = new BaseResponse<T>(data, ResponseCode.Error, ex.Message);
        res.InnerMessage = ex.InnerException?.Message;
        return res;
    }
}

public enum ResponseCode
{
    Success = 0,
    Error = 1,
}

public class PaginationOutput<T> : BaseResponse
{
    public PaginationOutput(IEnumerable<T> data, int totalRows, ResponseCode responseCode = ResponseCode.Success,
        string message = "") : base(responseCode, message)
    {
        Data = data;
        TotalRows = totalRows;
    }


    public IEnumerable<T> Data { get; set; }

    public int TotalRows { get; set; }

    public static PaginationOutput<T> Error(IEnumerable<T> data, Exception ex)
    {
        var res = new PaginationOutput<T>(data, 0, ResponseCode.Error, ex.Message);
        res.InnerMessage = ex.InnerException?.Message;
        return res;
    }
}