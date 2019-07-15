using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextClustering.Odin.KCluster.Models;

namespace TextClustering.Odin.KCluster.Interfaces
{
    public interface IClusterFactory<T> where T : class  
    {
        void SetNumberOfClustersRequired(int c);
        IList<ClusterResult<T>> BuildClusters(IList<DocumentVector<T>> vectors); 


    }
}
