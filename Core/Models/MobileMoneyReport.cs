using System;

namespace mmbm.Core.Models
{
    public class MobileMoneyReport
    {
        public int Id { get; set; }
        public int ConsolidatedReportId { get; set; }
        public ConsolidatedReport ConsolidatedReport { get; set; }
        public double OpeningEvalue { get; set; }
        public double OpeningCash { get; set; }
        public double? SentInEvalue { get; set; }
        public double? SentInCash { get; set; }
        public double? SentOutEvalue { get; set; }
        public double? SentOutCash { get; set; }
        public double ClosingEvalue { get; set; }
        public double ClosingCash { get; set; }
        public double Balance { get; set; }
        public DateTime? LastUpdate { get; set; }

    }
}