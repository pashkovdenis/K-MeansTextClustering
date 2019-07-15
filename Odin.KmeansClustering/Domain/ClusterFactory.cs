using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextClustering.Odin.KCluster.Interfaces;
using TextClustering.Odin.KCluster.Models;
using TextClustering.Odin.KCluster.Utils;

namespace TextClustering.Odin.KCluster.Domain
{
    public class ClusterFactory<T> : IClusterFactory<T> where T : class
    {
        int _clustersCount;  
        public IList<ClusterResult<T>> BuildClusters(IList<DocumentVector<T>> vectors)
        {
            var data = PrepareDocumentCluster(vectors);
            var result = data.Select(x => new ClusterResult<T>
            {
                Documents = x.GroupedDocument
            }).ToList();
            return result;
        }

        public List<Centeroid<T>> PrepareDocumentCluster(IList<DocumentVector<T>> documentCollection)
        {
            var centroidCollection = new List<Centeroid<T>>();
            var uniqRand = new HashSet<int>();

            GenerateRandomNumber(ref uniqRand, _clustersCount );

            foreach (int pos in uniqRand)
            {
                var c = new Centeroid<T>(); 
                c.GroupedDocument.Add(documentCollection[pos]);
                centroidCollection.Add(c);
            }
             
            InitializeClusterCentroid(out List<Centeroid<T>> resultSet, centroidCollection.Count);

            foreach (DocumentVector<T> obj in documentCollection)
            {
                int index = FindClosestClusterCenter(centroidCollection, obj);
                resultSet[index].GroupedDocument.Add(obj);
            } 
            return resultSet; 
        }

        private static void GenerateRandomNumber(ref HashSet<int> uniqRand, int k )
        { 
                for (int i = 0; i < k + 1; i++)
                {
                    uniqRand.Add(i);
                }  
        }

        private void InitializeClusterCentroid(out List<Centeroid<T>> centroid, int count)
        { 
            centroid = new List<Centeroid<T>>(); 
            for (int i = 0; i < count; i++)
            { 
                centroid.Add(new Centeroid<T>());
            }
        }

        private int FindClosestClusterCenter(List<Centeroid<T>> clusterCenter, DocumentVector<T> docVector)
        {
            float[] similarityMeasure = new float[clusterCenter.Count];
            int index = 0;
            float maxValue = similarityMeasure[0];





            Parallel.For(0, clusterCenter.Count, i =>
            {
                if (clusterCenter[i].GroupedDocument.Count > 0)
                {
                    similarityMeasure[i] = SimilarityMatrics
                                          .FindCosineSimilarity(clusterCenter[i].GroupedDocument[0].VectorSpace, docVector.VectorSpace);
                }
                if (similarityMeasure[i] > maxValue)
                {
                    maxValue = similarityMeasure[i];
                    index = i;
                }
            } );

            return index;
        }
         
        public void SetNumberOfClustersRequired(int c) => _clustersCount = c;
    }

}
