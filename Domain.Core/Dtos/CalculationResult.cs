using System.Collections.Generic;

namespace Domain.Core.Dtos
{
    public class CalculationResult
    {
        public CalculationResult(double rollingRetention, IEnumerable<HistogramColumn> columns)
        {
            RollingRetention = rollingRetention;
            Columns = columns;
        }

        public double RollingRetention { get; }
        public IEnumerable<HistogramColumn> Columns { get; }
    }
}