using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TextClustering.Odin.KCluster.Domain;
using TextClustering.Odin.KCluster.Models;
using TextClustering.Odin.KCluster.Services;

namespace test
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("K-Means Clustering Example...");
            while (true)
            {
              
                Console.WriteLine("Press Any key ");
                Console.ReadKey();
                Console.Clear();

                var  timer = new Stopwatch();
                     timer.Start();

                var service = new KMeansService<string>(new VectorFactory<string>(), new ClusterFactory<string>());
                    service.SetRequiredClustersCount(4);

                var result = service.BuildClusters(
                    new List<Document<string>>
                    {
                        new Document<string>("Microsoft Corporation (/ˈmaɪkrəˌsɒft/,[2][3] abbreviated as MS) is an American multinational technology company with headquarters in Redmond, Washington. It develops, manufactures, licenses, supports and sells computer software, consumer electronics, personal computers, and services. Its best known software products are the Microsoft Windows line of operating systems, the Microsoft Office suite, and the Internet Explorer and Edge web browsers. Its flagship hardware products are the Xbox video game consoles and the Microsoft Surface tablet lineup."),
                        new Document<string>("Microsoft was founded by Paul Allen and Bill Gates on April 4, 1975, to develop and sell BASIC interpreters for the Altair 8800. It rose to dominate the personal computer operating system market with MS-DOS in the mid-1980s, followed by Microsoft Windows"),
                        new Document<string>("The company's 1986 initial public offering (IPO), and subsequent rise in its share price, created three billionaires and an estimated 12,000 millionaires among Microsoft employees. Since the 1990s, it has increasingly diversified from the operating system market and has made a number of corporate acquisitions—their largest being the acquisition of LinkedIn for $26.2 billion in December 2016"),
                        new Document<string>("s of 2015, Microsoft is market-dominant in the IBM PC-compatible operating system market and the office software suite market, although it has lost the majority of the overall operating system market to Android")
                        ,
                        new Document<string>("Microsoft Corporation (/ˈmaɪkrəˌsɒft/,[2][3] abbreviated as MS) is an American multinational technology company with headquarters in Redmond, Washington. It develops, manufactures, licenses, supports and sells computer software, consumer electronics, personal computers, and services. Its best known software products are the Microsoft Windows line of operating systems, the Microsoft Office suite, and the Internet Explorer and Edge web browsers. Its flagship hardware products are the Xbox video game consoles and the Microsoft Surface tablet lineup."),
                        new Document<string>("Microsoft was founded by Paul Allen and Bill Gates on April 4, 1975, to develop and sell BASIC interpreters for the Altair 8800. It rose to dominate the personal computer operating system market with MS-DOS in the mid-1980s, followed by Microsoft Windows"),
                        new Document<string>("The company's 1986 initial public offering (IPO), and subsequent rise in its share price, created three billionaires and an estimated 12,000 millionaires among Microsoft employees. Since the 1990s, it has increasingly diversified from the operating system market and has made a number of corporate acquisitions—their largest being the acquisition of LinkedIn for $26.2 billion in December 2016"),
                        new Document<string>("s of 2015, Microsoft is market-dominant in the IBM PC-compatible operating system market and the office software suite market, although it has lost the majority of the overall operating system market to Android")
                        ,
                        new Document<string>("Microsoft Corporation (/ˈmaɪkrəˌsɒft/,[2][3] abbreviated as MS) is an American multinational technology company with headquarters in Redmond, Washington. It develops, manufactures, licenses, supports and sells computer software, consumer electronics, personal computers, and services. Its best known software products are the Microsoft Windows line of operating systems, the Microsoft Office suite, and the Internet Explorer and Edge web browsers. Its flagship hardware products are the Xbox video game consoles and the Microsoft Surface tablet lineup."),
                        new Document<string>("Microsoft was founded by Paul Allen and Bill Gates on April 4, 1975, to develop and sell BASIC interpreters for the Altair 8800. It rose to dominate the personal computer operating system market with MS-DOS in the mid-1980s, followed by Microsoft Windows"),
                        new Document<string>("The company's 1986 initial public offering (IPO), and subsequent rise in its share price, created three billionaires and an estimated 12,000 millionaires among Microsoft employees. Since the 1990s, it has increasingly diversified from the operating system market and has made a number of corporate acquisitions—their largest being the acquisition of LinkedIn for $26.2 billion in December 2016"),
                        new Document<string>("s of 2015, Microsoft is market-dominant in the IBM PC-compatible operating system market and the office software suite market, although it has lost the majority of the overall operating system market to Android")
                  
                    }).Result;




                foreach (var item in result.Where(r=>r.Documents.Count > 0))
                        {
                            Console.WriteLine(""); 
                            Console.WriteLine(">>>>>>>>>>>>>>{CLUSTER}<<<<<<<<<<<<"); 
                            foreach (var doc in item.Documents)
                                Console.WriteLine(doc.Content); 
                            Console.WriteLine("-----------"); 
                        }


                timer.Stop();
                Console.WriteLine("Timer elapsed {0}", timer.ElapsedMilliseconds);
            }


        ;
        }
    }
}
