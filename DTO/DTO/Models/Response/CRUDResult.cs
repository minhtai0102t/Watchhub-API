namespace Ecom_API.DTO.Models;
public class CRUDResult<T>
{
	public CRUDStatusCodeRes StatusCode { get; set; }

	public string Message { get; set; }

	public T Data { get; set; }
}

public enum CRUDStatusCodeRes
{
	Success,
	ResourceNotFound,
	Deny,
	NoExecute,
	Exists,
	InvalidAction,
	InvalidData,
	ReturnWithData,
	ResetContent
}

