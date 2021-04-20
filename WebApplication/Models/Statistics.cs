using System.Collections.Generic;

namespace WebApplication.Models
{
    public class Statistics
    {
        public double RollingRetention { get; set; }
        public IEnumerable<HistogramColumn> HistogramColumns { get; set;  }
    }
}