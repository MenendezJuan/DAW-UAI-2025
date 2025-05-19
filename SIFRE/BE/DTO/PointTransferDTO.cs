namespace BE.DTO
{
    public class PointTransferDTO
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public int Points { get; set; }
        public DateTime TransferDate { get; set; }
    }
}