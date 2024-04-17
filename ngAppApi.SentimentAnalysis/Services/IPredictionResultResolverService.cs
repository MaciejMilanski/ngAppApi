namespace ngAppApi.SentimentAnalysis.Services
{
    internal interface IPredictionResultResolverService
    {
        string ResolveSentimentName(string result);
    }
}
