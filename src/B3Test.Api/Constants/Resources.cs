namespace B3Test.Api.Constants
{
    public record Resources
    {
        public const string v1 = "1.0";
        public const string defaultRoute = "api/v{version:apiVersion}/[controller]";

        public const string error = "Ocorreu um erro inesperado.";
    }
}
