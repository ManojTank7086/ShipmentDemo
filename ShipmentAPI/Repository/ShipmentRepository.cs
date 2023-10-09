using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShipmentModel.CModel;
using ShipmentModel.DBContext;
using ShipmentModel.Models;


namespace ShipmentAPI.Repository
{
    public class ShipmentRepository : IShipmentRepository
    {
        readonly DemoContext _demoContext;
        public ShipmentRepository(DemoContext demoContext) => _demoContext = demoContext;
        public async Task<ShipmentInfo> CreateShipment(ShipmentInfoModel model)
        {
            try
            {
               
                var k = new ShipmentInfo
                {
                    AwbNo= model.AwbNo,
                    ConsigneeId=model.ConsigneeId,
                    ConsignorId=model.ConsignorId, 
                    DestinationAddress = model.DestinationAddress,
                    OriginAddress= model.OriginAddress,
                    OriginPointId=model.OriginPointId,
                    DestinationPointId=model.DestinationPointId,
                    CreateBy=model.CreateBy,
                    CreateDate=DateTime.Now,
                    Item= model.Item,
                    PktQty=model.PktQty ,
                    StatusId= model.StatusId
                };

                using var dbcontext = _demoContext;
                var result = await dbcontext.AddAsync(k);
                await dbcontext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message, ex.InnerException);
            }
        }

        public async Task<UpdateShipmentStatus> CreateShipmentStatus(UpdateShipmentStatusModel model)
        {
            try
            {
                using var dbcontext = _demoContext;
                var result = await dbcontext.AddAsync(model);
                await dbcontext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message, ex.InnerException);
            }

        }

        public async Task<bool> DeleteShipment(long productId)
        {
            try
            {
                using var dbcontext = _demoContext;
                var shipmentinfo = await _demoContext.ShipmentInfo.Where(x => x.Id == productId).FirstOrDefaultAsync();
                var result = dbcontext.Remove(shipmentinfo);
                 await dbcontext.SaveChangesAsync();
                return result != null ? true : false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message, ex.InnerException);
            }
        }

        public async Task<ShipmentInfo> GetShipmentById(long shipmentId)
        {
            try
            {
                using var dbcontext = _demoContext;
                var shipmentinfo = await dbcontext.ShipmentInfo.Where(x => x.Id == shipmentId).Include(b => b.Consignee).Include(c => c.Consignor).Include(d => d.Status).FirstOrDefaultAsync();
                if (shipmentinfo != null)
                    return shipmentinfo;
                else
                    return new();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message, ex.InnerException);
            }
        }

        public async Task<IEnumerable<ShipmentInfo>> GetShipments()
        {
            try
            {
                using var dbcontext = _demoContext;
                var list = await dbcontext.ShipmentInfo.Include(b => b.Consignee).Include(c => c.Consignor).Include(d => d.Status).ToListAsync();

                if (list.Count > 0)
                    return list;
                else
                    return list;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message, ex.InnerException);
            }
        }

        public async Task<ShipmentInfo> UpdateShipment(ShipmentInfoModel model)
        {
            try
            {
                var k = new ShipmentInfo
                {
                    Id = model.Id,
                    AwbNo = model.AwbNo,
                    ConsigneeId = model.ConsigneeId,
                    ConsignorId = model.ConsignorId,
                    DestinationAddress = model.DestinationAddress,
                    OriginAddress = model.OriginAddress,
                    OriginPointId = model.OriginPointId,
                    DestinationPointId = model.DestinationPointId,
                    CreateBy = model.CreateBy,
                    CreateDate = DateTime.Now,
                    Item = model.Item,
                    PktQty = model.PktQty,
                    StatusId = model.StatusId,
                };
                using var dbcontext = _demoContext;
                var result = dbcontext.Update(k);
                await dbcontext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message, ex.InnerException);
            }
        }
    }
}
