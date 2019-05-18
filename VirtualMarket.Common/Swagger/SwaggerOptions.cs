namespace VirtualMarket.Common.Swagger
{
    public class SwaggerOptions
    {
        public bool Enabled { get; set; }
        public bool ReDocEnable { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public string RoutePrefix { get; set; }
        public bool IncludeSecurity { get; set; }
    }
}
