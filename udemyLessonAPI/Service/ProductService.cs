using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using udemyLessonAPI.Domain;
using udemyLessonAPI.Domain.Repositories;
using udemyLessonAPI.Domain.Response;
using udemyLessonAPI.Domain.Service;
using udemyLessonAPI.Domain.UnitOfWork;

namespace udemyLessonAPI.Service
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;


        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ProductResponse> AddProduct(Product product)
        {
            try
            {

                await productRepository.AddProductAsync(product);
                await unitOfWork.CompleteAsync();

                return new ProductResponse(product);

            }
            catch(Exception ex)
            {
                return new ProductResponse($"Ürün Eklenirken Hata Oluştu{ ex.Message }");

            }

        }

        public async Task<ProductResponse> findByIdAsync(int ProductId)
        {
            try
            {
                Product product = await productRepository.findByIdAsync(ProductId);
                if(product == null)
                {
                    return new ProductResponse("Ürün Bulunamadı.");

                }

                return new ProductResponse(product);

            }
            catch(Exception ex)
            {
                return new ProductResponse($"Ürün Bulunurken İşlem Sırasında Hata Oluştu{ ex.Message }");
            }
        }

        public async Task<ProductListResponse> ListAsync()
        {
            try
            {
                IEnumerable<Product> products = await productRepository.ListAsync();

                return new ProductListResponse(products);

            }
            catch(Exception ex)
            {
                return new ProductListResponse($"Ürünler Listelenirken İşlem Sırasında Hata Oluştu{ ex.Message }");
            }
        }

        public async Task<ProductResponse> RemoveProduct(int ProductId)
        {
            try
            {
                Product product = await productRepository.findByIdAsync(ProductId);

                if(product == null)
                {

                    return new ProductResponse("Ürün Bulunamadı"); 
                }
                else
                {
                    await productRepository.RemoveProductAsync(ProductId);
                    await unitOfWork.CompleteAsync();

                    return new ProductResponse(product);

                }


            }
            catch(Exception ex)
            {
                return new ProductResponse($"Ürünler Silinirken İşlem Sırasında Hata Oluştu{ ex.Message }");
            }
        }

        public async Task<ProductResponse> UpdateProduct(Product product, int ProductId)
        {
            try
            {
                Product firstProduct = await productRepository.findByIdAsync(ProductId);
                if(firstProduct == null)
                {
                    return new ProductResponse("Güncellemeye çalışılan ürün bulunamadı.");

                }

                firstProduct.Name = product.Name;
                firstProduct.Category = product.Category;
                firstProduct.Price = product.Price;

                productRepository.UpdateProduct(firstProduct);
                await unitOfWork.CompleteAsync();

                return new ProductResponse(firstProduct);


            }
            catch(Exception ex)
            {
                return new ProductResponse($"Ürünler Güncellenirken İşlem Sırasında Hata Oluştu{ ex.Message }");
            }
        }
    }
}
