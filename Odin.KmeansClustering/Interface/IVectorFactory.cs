using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextClustering.Odin.KCluster.Models;

namespace TextClustering.Odin.KCluster.Interfaces
{
    public  interface IVectorFactory<T> where T : class  
    { 
        IList<DocumentVector<T>> BuildVectorSpace(IList<Document<T>> documents);    

    } 
     
}
