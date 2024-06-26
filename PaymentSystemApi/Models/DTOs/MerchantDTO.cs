﻿namespace PaymentSystemApi.DTOs
{
    public class MerchantDTO
    {
        public string BusinessId { get; set; }  
        public string BusinessName { get; set;}
        public string FirstName { get; set;}    
        public string SurName { get; set;}
        public DateTime DateOfEstablishment { get; set; }   
        public string PhoneNumber { get; set;}  
        public double AverageTransactionVolume { get; set; }    

    }
}
