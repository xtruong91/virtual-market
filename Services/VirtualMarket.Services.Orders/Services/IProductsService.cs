﻿using RestEase;
using System;
using System.Threading.Tasks;
using VirtualMarket.Services.Orders.Dto;

namespace VirtualMarket.Services.Orders.Services
{
    public interface IProductsService
    {
        [AllowAnyStatusCode]
        [Get("products/{id}")]
        Task<OrderItemDto> GetAsync([Path] Guid id);
    }
}
