using XML4PFR.Engine.Builders;

namespace XML4PFR.Engine.Handlers
{
    interface IStrategy
    {
        RequestBuilder Handler(string file, string provider, int fileNumber);
        string Filter { get; }
    }
}
