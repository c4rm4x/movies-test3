namespace Movies.Application.CreateRating
{
    public class ResourceNotFoundResponse : CreateRatingCommandResponse
    {
        public string Message { get; private set; }

        public ResourceNotFoundResponse(string message)
        {
            Message = message;
        }
    }
}
