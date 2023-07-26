using DTO.DTO.Models;
using EBird.Application.Model.PagingModel;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;

namespace Ecom_API.Service;

public interface IProductFeedbackService : IDisposable
{
    Task<PagedList<ProductFeedbackFullRes>> GetAll(QueryStringParameters pagingParams);
    Task<PagedList<ProductFeedbackFullRes>> GetByUserId(QueryStringParameters query, int userId);
    Task<PagedList<ProductFeedbackFullRes>> GetByProductTypeId(QueryStringParameters query, int productTypeId);
    Task<ProductFeedbackFullRes> GetById(int id);
    Task<bool> Create(ProductFeedbackCreateReq req);
    Task<bool> SoftDelete(int id);
    Task<bool> Delete(int id);
}

