using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextClustering.Odin.KCluster.Models
{
    public class ClusterResult<T> where T : class
    {

        public IList<DocumentVector<T>> Documents { set; get; } 

        public int Count { get { return Documents.Count; } }   

    }
}
