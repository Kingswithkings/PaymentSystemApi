﻿using PaymentSystemApi.DTOs;

namespace PaymentSystemApi.Interfaces.IServices
{
    public interface IMerchantService
    {
        Task<MerchantDTO> GetMerchantByIdAsync(int merchantId);
        Task<IEnumerable<MerchantDTO>> GetAllMerchantAsync();
        Task<bool> AddMerchantAsync(MerchantDTO merchantDTO);
        Task UpdateMerchantAsync(int merchantId, MerchantDTO merchantDTO);
        Task DeleteMerchantAsync(int merchantId);   
    }
}
