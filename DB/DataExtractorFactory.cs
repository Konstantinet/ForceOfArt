using System;

namespace DB
{
    public interface DataExtractorFactory
    {
        public DataProcessor GetProcessor();
    }
}
