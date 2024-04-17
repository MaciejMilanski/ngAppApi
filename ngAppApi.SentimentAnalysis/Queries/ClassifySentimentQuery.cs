using ngAppApi.Core.Cqs;
using ngAppApi.SentimentAnalysis.Models;

namespace ngAppApi.SentimentAnalysis.Queries
{
    public class ClassifySentimentQuery : IQuery<ClassificationResultModel>
    {
        public ClassifySentimentQuery(string sentence)
        {
            Sentence = sentence;
        }

        public string Sentence { get; set; }
    }
}
