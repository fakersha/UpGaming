namespace UpGaming.Domain.Entities
{
    public class Scores
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }
    }
}
