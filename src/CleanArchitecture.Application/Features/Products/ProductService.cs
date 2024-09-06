using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Products.Create;
using CleanArchitecture.Application.Features.Products.Dto;
using CleanArchitecture.Application.Features.Products.Update;
using CleanArchitecture.Application.Features.Products.UpdateStock;
using CleanArchitecture.Domain.Entities;
using FluentValidation;
using System.Net;

namespace CleanArchitecture.Application.Features.Products
{
    public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IValidator<CreateProductRequest> createProductRequestValidator, IMapper mapper) : IProductService
    {
        public async Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request)
        {
            var anyProduct = await productRepository.AnyAsync(x=>x.Name == request.Name);

            if (anyProduct)
            {
                return ServiceResult<CreateProductResponse>.Fail($"Product with name {request.Name} already exists", HttpStatusCode.BadRequest);
            }

            var product = mapper.Map<Product>(request);

            await productRepository.AddAsync(product);

            await unitOfWork.SaveChangesAsync();

            return ServiceResult<CreateProductResponse>.SuccessAsCreated(mapper.Map<CreateProductResponse>(product.Id),$"api/products/{product.Id}");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);


            productRepository.Delete(product!);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<ProductDto>>> GetAllListAsync()
        {
            var products = await productRepository.GetAllAsync();

            var productsAsDto = mapper.Map<List<ProductDto>>(products);

            return ServiceResult<List<ProductDto>>.Success(productsAsDto);
        }

        public async Task<ServiceResult<ProductDto?>> GetByIdAsync(int id)
        {
           var product = await productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return ServiceResult<ProductDto?>.Fail($"Product not found id = {id}",HttpStatusCode.NotFound);
            }
            var productAsDto = mapper.Map<ProductDto>(product);

            return ServiceResult<ProductDto?>.Success(productAsDto);
        }

        public async Task<ServiceResult<List<ProductDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            var products = await productRepository.GetAllPagedAsync(pageNumber, pageSize);

            var productsAsDto = mapper.Map<List<ProductDto>>(products);

            return ServiceResult<List<ProductDto>>.Success(productsAsDto);
        }

        public async Task<ServiceResult<List<ProductDto>>> GetTopPriceProductsAsync(int count)
        {
            var product = await productRepository.GetTopPriceProductsAsync(count);

            var productAsDto = mapper.Map<List<ProductDto>>(product);

            return new ServiceResult<List<ProductDto>>()
            {
                Data = productAsDto
            };
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request)
        {
            var isProductNameExist = await productRepository.AnyAsync(x=>x.Name == request.Name && x.Id != id);

            if (isProductNameExist)
            {
                return ServiceResult.Fail($"Product with name {request.Name} already exists", HttpStatusCode.BadRequest);
            }

            var product = mapper.Map<Product>(request);
            product.Id = id;

            productRepository.Update(product);

            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> UpdateStockAsync(UpdateProductsStockRequest request)
        {
            var product = await productRepository.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                return ServiceResult.Fail($"Product not found id = {request.ProductId}", HttpStatusCode.NotFound);
            }

            //basic
            product.Stock = request.Quantity;

            productRepository.Update(product);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}