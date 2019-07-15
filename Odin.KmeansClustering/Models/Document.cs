using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextClustering.Odin.KCluster.Models
{
    public class Document<T> where T : class 
    {
        private T _data;
        public Document(T data) => _data = data; 
        public Document()
        {
        } 
        public T GetData() => _data;  
        public override string ToString() => _data.ToString(); 
    }
}
