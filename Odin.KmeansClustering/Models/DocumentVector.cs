using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextClustering.Odin.KCluster.Models
{
    public class DocumentVector<T> where T:  class 
    {

        public DocumentVector()
        { 
        }

        public DocumentVector(T arg)
        {
            Content = arg;  
        } 
        public T  Content { set; get; }
        public float[] VectorSpace { get; set; } 

    }
}
