namespace ngAppApi.SentimentAnalysis.Services.Implementations
{
    internal class PredictionResultResolverService : IPredictionResultResolverService
    {
        public string ResolveSentimentName(string result)
        {
            switch (result)
            {
                case "0":
                    return "Negative";
                case "1":
                    return "Positive";
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
