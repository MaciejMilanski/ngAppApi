using ngAppApi.Classifier.SampleClassification;
using ngAppApi.Core;
using ngAppApi.Core.Cqs;
using ngAppApi.SentimentAnalysis.Models;
using ngAppApi.SentimentAnalysis.Services;
namespace ngAppApi.SentimentAnalysis.Queries.Handlers
{
    internal class ClassifySentimentQueryHandler : QueryHandler<ClassifySentimentQuery, ClassificationResultModel>
    {
        private readonly IPredictionResultResolverService _predictionResultResolverService;

        public ClassifySentimentQueryHandler(IPredictionResultResolverService predictionResultResolverService)
        {
            _predictionResultResolverService = predictionResultResolverService;
        }

        public override ClassificationResultModel HandleQuery(ClassifySentimentQuery query)
        {
            SampleClassification.ModelInput sampleData = new SampleClassification.ModelInput()
            {
                Col0 = query.Sentence,
            };

            var scoresWithLabels = SampleClassification.PredictAllLabels(sampleData);


            var result = scoresWithLabels.Single(s => s.Value >= Consts.SentimentClassification.ConfidenceTreshold);
            var rejectedLabel = scoresWithLabels.Single(s => s.Value < Consts.SentimentClassification.ConfidenceTreshold);

            return new ClassificationResultModel(
                sentiment: _predictionResultResolverService.ResolveSentimentName(result.Key),
                certainyOfCorrectClassification: result.Value.ToString(),
                certainyOfIncorrectClassification: result.Value.ToString());
        }
    }
}
