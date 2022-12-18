using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForceOfArt.Models
{
    public interface DataExtractorFactory
    {
        public DataProcessor GetProcessor();
    }
}
