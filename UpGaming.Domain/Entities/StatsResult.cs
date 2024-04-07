namespace UpGaming.Domain.Entities
{
    public class StatsResult
    {
        public double DailyAverage { get; set; }
        public double MonthlyAverage { get; set; }
        public int MaxDailyScore { get; set; }
        public int MaxMonthlyScore { get; set; }
        public int MaxMonthlyScoreResponseType { get; set; }
    }
}
