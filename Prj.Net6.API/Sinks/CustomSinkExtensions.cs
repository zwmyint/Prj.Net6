using Serilog.Configuration;
using Serilog;

namespace Prj.Net6.API.Sinks
{
    public static class CustomSinkExtensions
    {
        public static LoggerConfiguration CustomSink(this LoggerSinkConfiguration loggerConfiguration)
        {
            return loggerConfiguration.Sink(new CustomSink());
        }
    }
}
