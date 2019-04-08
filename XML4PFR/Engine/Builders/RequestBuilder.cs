using System;

namespace XML4PFR.Engine.Builders
{
    public abstract class RequestBuilder
    {
        protected readonly int _size;
        protected readonly string _provider;
        protected readonly int _fileNumber;
        protected readonly string _file;

        public EventHandler<RequestBuilderEventArgs> Information;
        public EventHandler<RequestBuilderEventArgs> Error;
        public EventHandler<RequestBuilderEventArgs> Complete;

        protected void RaiseInformation(string message)
        {
            EventHandler<RequestBuilderEventArgs> temp = Information;
            temp?.Invoke(this, new RequestBuilderEventArgs(message));
        }

        protected void RaiseError(string message)
        {
            EventHandler<RequestBuilderEventArgs> temp = Error;
            temp?.Invoke(this, new RequestBuilderEventArgs(message));
        }

        protected void RaiseComplete(string message)
        {
            EventHandler<RequestBuilderEventArgs> temp = Complete;
            temp?.Invoke(this, new RequestBuilderEventArgs(message));
        }

        protected RequestBuilder(string file, string provider, int fileNumber, int size)
        {
            _file = file;
            _provider = provider;
            _fileNumber = fileNumber;            
            _size = size;
        }

        public abstract void BuildTo(string path);
    }

    public class RequestBuilderEventArgs : EventArgs
    {
        public string Message { get; set; }

        public RequestBuilderEventArgs(string message)
        {
            Message = message;
        }
    }
}
