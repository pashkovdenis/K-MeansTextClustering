using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextClustering.Odin.KCluster.Models
{
    public  class   Centeroid <T> where T :  class 
    {
        public Centeroid()
        {
            GroupedDocument = new List<DocumentVector<T>>(); 
        }
        public IList<DocumentVector<T>> GroupedDocument { get;  }  

    }
}
