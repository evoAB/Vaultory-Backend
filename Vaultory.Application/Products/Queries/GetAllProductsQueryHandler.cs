using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vaultory.Application.Common.Interfaces;
using Vaultory.Application.Common.Models;
using Vaultory.Application.Products.Dtos;
using Vaultory.Domain.Entities;

namespace Vaultory.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PaginatedList<ProductDto>>
{
    private readonly IVaultoryDbContext _context;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IVaultoryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Products
            // .AsNoTracking()
            .Where(p => !p.IsDeleted)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Name)) query = query.Where(p => p.Name.Contains(request.Name));

        if (!string.IsNullOrWhiteSpace(request.SKU)) query = query.Where(p => p.Name.Contains(request.SKU));

        if (request.CategoryId.HasValue) query = query.Where(p => p.CategoryId == request.CategoryId.Value);

        if (request.LocationId.HasValue) query = query.Where(p => p.LocationId == request.LocationId.Value);

        if (request.MinPrice.HasValue) query = query.Where(p => p.Price >= request.MinPrice);

        if (request.MaxPrice.HasValue) query = query.Where(p => p.Price <= request.MaxPrice);

        if (request.MinQuantity.HasValue) query = query.Where(p => p.Quantity >= request.MinQuantity);

        if (request.MaxQuantity.HasValue) query = query.Where(p => p.Quantity <= request.MaxQuantity);

        query = request.SortBy?.ToLower() switch
        {

            "name" => request.IsDescending ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name),
            "quantity" => request.IsDescending ? query.OrderByDescending(p => p.Quantity) : query.OrderBy(p => p.Quantity),
            "price" => request.IsDescending ? query.OrderByDescending(p => p.Price) : query.OrderBy(p => p.Price),
            _ => query.OrderBy(p => p.Id)
        };

        var products = query.ProjectTo<ProductDto>(_mapper.ConfigurationProvider);

        return await PaginatedList<ProductDto>.CreateAsync(products, request.PageNumber, request.PageSize, cancellationToken);
    }
}