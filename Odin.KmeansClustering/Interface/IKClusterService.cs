using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextClustering.Odin.KCluster.Models;

namespace TextClustering.Odin.KCluster.Interfaces
{
    public interface IKClusterService<T> where T: class 
    { 
        void SetRequiredClustersCount(int count);
        int CalculateDefaultClustersCount(int documentsCount);
        Task<IList<ClusterResult<T>>> BuildClusters(IList<Document<T>> documents); 
    }
}
