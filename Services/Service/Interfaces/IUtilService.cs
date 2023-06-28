namespace Ecom_API.Service;

public interface IUtilService : IDisposable
{
    public string GetIpAddress();
    public String HmacSHA512(string key, String inputData);
}

