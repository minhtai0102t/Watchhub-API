using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using Microsoft.Extensions.Options;
using Services.CommonConfig;

namespace Ecom_API.Helpers;
public class GoogleHelperService
{
    private readonly AppSettings _appsetting;
    public GoogleHelperService(IOptions<AppSettings> appSettings){
        _appsetting = appSettings.Value;
    }
    public async Task<IList<Result>> SearchProducts(string searchTerm)
    {
        var service = new CustomsearchService(new BaseClientService.Initializer
        {
            ApiKey = "AIzaSyDaaXaUQZuMDVb-EDQbRSIlpNzDoXbfx1Y"
        });

        var listRequest = service.Cse.List();
        listRequest.Cx = "50a89d0d866644651";
        listRequest.Q = searchTerm;

        var search = await listRequest.ExecuteAsync();
        return search.Items;
    }

}