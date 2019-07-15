using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextClustering.Odin.KCluster.Interfaces;
using TextClustering.Odin.KCluster.Models;

namespace TextClustering.Odin.KCluster.Domain
{
    public class VectorFactory<T> : IVectorFactory<T> where T : class
    {
        readonly Regex SplitExpression = new Regex("([ \\t{}()\",:;. \n])", RegexOptions.CultureInvariant);
        IEnumerable<string[]> documentValues; 

         
        public IList<DocumentVector<T>> BuildVectorSpace(IList<Document<T>> documents)
        {
            var distinctTerms = new HashSet<string>();
            var documentVectorSpace = new List<DocumentVector<T>>();
            DocumentVector<T> _documentVector;
            float[] space; 

            documentValues = documents.Select(d => SplitExpression.Split(d.ToString().ToLower())).Where(x => x.Length >= 2).ToList();

            foreach (var documentContent in documents)
            {
                foreach (string term in SplitExpression.Split(documentContent.ToString()).Where(t=>t.Length >= 2))
                    distinctTerms.Add(term);
            }

            foreach (var document in documents)
            {
                int count = 0;
                space = new float[distinctTerms.Count];
                Parallel.ForEach(distinctTerms, term =>
                {
                    space[count] = FindTFIDF(document.ToString(), term);
                    count++;
                });
                _documentVector = new DocumentVector<T>();
                _documentVector.Content = document.GetData();
                _documentVector.VectorSpace = space;
                documentVectorSpace.Add(_documentVector);
            }

            return documentVectorSpace;
        }

        private float FindTFIDF(string document, string term)
        {
            var tf = FindTermFrequency(document, term);
            var idf = FindInverseDocumentFrequency(term.ToLower());
            return tf * idf;
        }

        private float FindTermFrequency(string document, string term)
        {
            var splitted = SplitExpression.Split(document);
            int count = splitted.Count(s => s.ToUpper() == term.ToUpper());
            return ((float)count / (splitted.Count()));
        }

        private float FindInverseDocumentFrequency(string term)
        {
            int count = documentValues.Count(d => d.Any(w => w  == term )); 
            return (float)Math.Log((float)documentValues.Count() / count);
        }


    }
}
