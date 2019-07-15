using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextClustering.Odin.KCluster.Interfaces;
using TextClustering.Odin.KCluster.Models;

namespace TextClustering.Odin.KCluster.Services
{
    public class KMeansService<T> : IKClusterService<T> where T : class
    {
        private int _clusterCount;

        private readonly IVectorFactory<T> _vectorFactory;
        private readonly IClusterFactory<T> _clusterFactory; 
        public KMeansService() => _clusterCount = 2; 
        public KMeansService(IVectorFactory<T> vectorFactory, IClusterFactory<T> clusterFactory) : this()
        {
            _vectorFactory = vectorFactory;
            _clusterFactory = clusterFactory;
        }
        public int CalculateDefaultClustersCount(int documentsCount)
            => (int)Math.Sqrt(documentsCount / 0.5); 
        public async Task<IList<ClusterResult<T>>> BuildClusters(IList<Document<T>> documents)
        {
            var timer = new Stopwatch();
            timer.Start(); 
            var vectors = await Task.FromResult(_vectorFactory.BuildVectorSpace(documents));
            timer.Stop();

            Console.WriteLine("Elapsed {0}", timer.ElapsedMilliseconds);

 

            var task = await Task<IList<ClusterResult<T>>>.Factory.StartNew(() =>
            {
                _clusterFactory.SetNumberOfClustersRequired(_clusterCount);
                return _clusterFactory.BuildClusters(vectors);
            } , TaskCreationOptions.LongRunning).ConfigureAwait(false);

            return  task;
        }
        public void SetRequiredClustersCount(int count) => _clusterCount = Math.Abs(count);

    }
}
