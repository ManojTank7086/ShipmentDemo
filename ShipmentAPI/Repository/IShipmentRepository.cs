using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShipmentModel.CModel;
using ShipmentModel.Models;

namespace ShipmentAPI.Repository
{
    public interface IShipmentRepository
    {
        Task<IEnumerable<ShipmentInfo>> GetShipments();
        Task<ShipmentInfo> GetShipmentById(long shipmentId);
        Task <ShipmentInfo> CreateShipment(ShipmentInfoModel model);
        Task <bool> DeleteShipment(long productId);
        Task <ShipmentInfo> UpdateShipment(ShipmentInfoModel model);
        Task <UpdateShipmentStatus> CreateShipmentStatus(UpdateShipmentStatusModel model);
    }
}
