using System;
using System.Collections.Generic;

namespace DB
{
    public abstract class DataProcessor
    {
        protected List<ArtObject> Result;

        public abstract void Process();
        public List<ArtObject> GetData()=>Result;
    }
}
