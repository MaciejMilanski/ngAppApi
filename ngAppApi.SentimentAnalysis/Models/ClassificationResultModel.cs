namespace ngAppApi.SentimentAnalysis.Models
{
    public class ClassificationResultModel
    {
        public ClassificationResultModel(
            string sentiment,
            string certainyOfCorrectClassification,
            string certainyOfIncorrectClassification)
        {
            Sentiment = sentiment;
            CertainyOfCorrectClassification = certainyOfCorrectClassification;
            CertainyOfIncorrectClassification = certainyOfIncorrectClassification;
        }

        public string Sentiment { get; set; }
        public string CertainyOfCorrectClassification { get; set; }
        public string CertainyOfIncorrectClassification { get; set; }
    }
}
