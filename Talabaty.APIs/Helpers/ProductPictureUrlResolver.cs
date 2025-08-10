﻿using AutoMapper;
using Talabaty.APIs.DTOs;
using Talabaty.Core.Entity;

namespace Talabaty.APIs.Helpers
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _configuration;
        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["ApiBaseUrl"]}{source.PictureUrl}";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}



