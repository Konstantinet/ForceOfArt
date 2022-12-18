using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForceOfArt.Models
{
    public abstract class DataProcessor
    {
        protected List<ArtObject> Result;

        public abstract void Process();
        public List<ArtObject> GetData()=>Result;
    }
}
