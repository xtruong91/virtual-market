using App.Metrics;
using App.Metrics.Counter;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualMarket.Discounts.Metrics
{
    public class MetricsRegistry : IMetricsRegistry
    {
        private readonly IMetricsRoot _metricsRoot;
        private readonly CounterOptions _findCDiscountsQueries
            = new CounterOptions { Name = "find-discount" };

        public MetricsRegistry(IMetricsRoot metricsRoot)
            => _metricsRoot = metricsRoot;
        public void IncrementFindDiscountsQuery()
            => _metricsRoot.Measure.Counter.Increment(_findCDiscountsQueries);
    }
}
