﻿namespace Service.DTOs.Admin.MenuVariants
{
    public class MenuVariantDetailDto
    {
        public string Option { get; set; }
        public decimal AdditionalPrice { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string VariantType { get; set; }
        public string Menu { get; set; }
        public bool IsSingleChoice { get; set; }
    }
}
