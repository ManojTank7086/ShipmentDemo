namespace ShipmentAPI.DBContext
{
    public class EntityInformation
    {
        public long CreateBy {  get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }
        public string ModifiedUserName { get; set; }
    }
}
