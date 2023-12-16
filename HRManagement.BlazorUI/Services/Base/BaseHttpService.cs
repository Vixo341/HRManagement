namespace HRManagement.BlazorUI.Services.Base;

public class BaseHttpService
{
    protected IClient _client;

    public BaseHttpService(IClient client)
    {
        _client = client;
    }
    
    protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
    {
        switch (ex.StatusCode)
        {
            case 400:
                return new Response<Guid>()
                    { Message = "Bad Request", ValidationErrors = ex.Response, Success = false };
            break;
            case 404:
                return new Response<Guid>()
                    { Message = "Not Found", ValidationErrors = ex.Response, Success = false };
            break;
            case 500:
                return new Response<Guid>()
                    { Message = "Server Error", ValidationErrors = ex.Response, Success = false };
            break;
            default:
                return new Response<Guid>()
                    { Message = "Unknown Error", ValidationErrors = ex.Response, Success = false };
        }
    }
}