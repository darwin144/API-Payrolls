namespace API_eSIP.ViewModels.Overtimes
{
    public class OvertimeVM
    {
        public Guid Id { get; set; }
        public DateTime SubmitDate { get; set; }
        public string Deskripsi { get; set; }
        public int Paid { get; set; }
        public Types Tipe { get; set; }
        public Status Status { get; set; }
        public Types Type { get; set; }
    }
}
