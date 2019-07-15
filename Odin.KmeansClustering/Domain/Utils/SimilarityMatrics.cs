using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace TextClustering.Odin.KCluster.Utils
{

    public static class SimilarityMatrics
    {
        public static float FindCosineSimilarity(float[] vecA, float[] vecB)
        {
            var dotProduct = DotProduct(vecA, vecB);
            var magnitudeOfA = Magnitude(vecA);
            var magnitudeOfB = Magnitude(vecB);
            float result = dotProduct / (magnitudeOfA * magnitudeOfB); 

            return float.IsNaN(result) ? 0 : result;

            float Magnitude(float[] vector)
            {
                return (float)Math.Sqrt(DotProduct(vector, vector));
            }
        }
        public static float DotProduct(float[] vecA, float[] vecB)
        =>  Vector.Dot( Vector.Multiply(new Vector<float>(vecA), new Vector<float>(vecB)), Vector<float>.One);
         
       

    }
}
