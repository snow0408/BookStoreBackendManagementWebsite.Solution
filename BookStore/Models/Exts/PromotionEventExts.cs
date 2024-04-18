using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Exts
{
    public static class PromotionEventExts
    {
        public static PromotionEventDto ToPromotionEventDto(this PromotionEventVm vm)
        {
            return new PromotionEventDto
            {
                EventName = vm.EventName,
                EventSerialNumber = vm.EventSerialNumber,
                EventDescription = vm.EventDescription,
                DiscountType = vm.DiscountType,
                EventType = vm.EventType,
                DiscountRate = vm.DiscountRate,
                OfferStatus = vm.OfferStatus,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate,

            };
        }

        public static PromotionEventVm ToPromotionEventVm(this PromotionEventDto dto)
        {
            return new PromotionEventVm
            {
                EventName = dto.EventName,
                EventSerialNumber = dto.EventSerialNumber,
                EventDescription = dto.EventDescription,
                DiscountType = dto.DiscountType,
                EventType = dto.EventType,
                DiscountRate = dto.DiscountRate,
                OfferStatus = dto.OfferStatus,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
               
            };
        }

        //public static CouponDto ToCouponDto(this Coupon entity)
        //{
        //    var dto = new CouponDto();
        //    if (entity != null)
        //    {
        //        dto.CouponID = entity.CouponID;
        //        dto.PromotionID = entity.PromotionID;
        //        dto.Code = entity.Code;
        //        dto.StartDate = entity.StartDate;
        //        dto.EndDate = entity.EndDate;
        //        dto.Valid = entity.Valid;
        //        dto.Description = entity.Description;
        //        dto.AvailabilityCount = entity.AvailabilityCount;
        //        dto.UsingStatus = entity.UsingStatus;
        //        dto.MinimumValue = entity.MinimumValue;
        //        dto.DiscountLimit = entity.DiscountLimit;
        //    }
        //    return dto;
        //}
    }
}