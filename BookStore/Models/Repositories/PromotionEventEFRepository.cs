using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Repositories
{
    public class PromotionEventEFRepository : IPromotionEventRepository
    {
        public void Create(PromotionEventDto dto)
        {
            var db = new AppDbContext();
            var model = new PromotionEvent
            {
                EventID = dto.EventID,
                EventName = dto.EventName,
                EventSerialNumber = dto.EventSerialNumber,
                EventDescription = dto.EventDescription,
                DiscountType = dto.DiscountType,
                EventType = dto.EventType,
                DiscountRate = dto.DiscountRate,
                OfferStatus = dto.OfferStatus,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                EventDetails = dto.EventDetails,
                EventFile = dto.EventFile
            };
            db.PromotionEvents.Add(model);
            db.SaveChanges();

        }
        public List<PromotionEventDto> GetAll()
        {
            var db = new AppDbContext();
            var model = db.PromotionEvents.ToList();
            return model.Select(x => new PromotionEventDto
            {
                EventID = x.EventID,
                EventName = x.EventName,
                EventSerialNumber = x.EventSerialNumber,
                EventDescription = x.EventDescription,
                DiscountType = x.DiscountType,
                EventType = x.EventType,
                DiscountRate = x.DiscountRate,
                OfferStatus = x.OfferStatus,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                EventDetails = x.EventDetails,
                EventFile = x.EventFile
            }).ToList();
        }

        IEnumerable<PromotionEventDto> IPromotionEventRepository.GetAll()
        {
            var db = new AppDbContext();
            var models = db.PromotionEvents
                .AsNoTracking()
                .Select(x => new PromotionEventDto
                {
                    EventID = x.EventID,
                    EventName = x.EventName,
                    EventSerialNumber = x.EventSerialNumber,
                    EventDescription = x.EventDescription,
                    DiscountType = x.DiscountType,
                    EventType = x.EventType,
                    DiscountRate = x.DiscountRate,
                    OfferStatus = x.OfferStatus,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    EventDetails = x.EventDetails,
                    EventFile = x.EventFile
                });
            return models;
        }

        public void Update(PromotionEventDto dto)
        {
            var db = new AppDbContext();
            var model = db.PromotionEvents.Find(dto.EventID);
            model.EventID = dto.EventID;
            model.EventName = dto.EventName;
            model.EventSerialNumber = dto.EventSerialNumber;
            model.EventDescription = dto.EventDescription;
            model.DiscountType = dto.DiscountType;
            model.EventType = dto.EventType;
            model.DiscountRate = dto.DiscountRate;
            model.OfferStatus = dto.OfferStatus;
            model.StartDate = dto.StartDate;
            model.EndDate = dto.EndDate;
            model.EventDetails = dto.EventDetails;
            model.EventFile = dto.EventFile;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var db = new AppDbContext();
            var model = db.PromotionEvents.Find(id);
            db.PromotionEvents.Remove(model);
            db.SaveChanges();
        }

        public List<PromotionEventDto> Search(int page, int pageSize)
        {

            var db = new AppDbContext();
            var model = db.PromotionEvents.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var result = new List<PromotionEventDto>();
            foreach (var item in model)
            {
                result.Add(new PromotionEventDto
                {
                    EventID = item.EventID,
                    EventName = item.EventName,
                    EventSerialNumber = item.EventSerialNumber,
                    EventDescription = item.EventDescription,
                    DiscountType = item.DiscountType,
                    EventType = item.EventType,
                    DiscountRate = item.DiscountRate,
                    OfferStatus = item.OfferStatus,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    EventDetails = item.EventDetails,
                    EventFile = item.EventFile
                });
            }
            return result;
        }

        public List<PromotionEventDto> SearchEvent(string keyword)
        {
            var db = new AppDbContext();
            var model = db.PromotionEvents.ToList();
            if (!string.IsNullOrEmpty(keyword))
            {
                model= model.Where(x => x.EventName.Contains(keyword)).ToList();
            }
            var result = new List<PromotionEventDto>();
            foreach (var item in model)
            {
                result.Add(new PromotionEventDto
                {
                    EventID = item.EventID,
                    EventName = item.EventName,
                    EventSerialNumber = item.EventSerialNumber,
                    EventDescription = item.EventDescription,
                    DiscountType = item.DiscountType,
                    EventType = item.EventType,
                    DiscountRate = item.DiscountRate,
                    OfferStatus = item.OfferStatus,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    EventDetails = item.EventDetails,
                    EventFile = item.EventFile
                });
            }
            return result;
        }

        public void Save()
        {
            var db = new AppDbContext();
            db.SaveChanges();
        }


    }
}