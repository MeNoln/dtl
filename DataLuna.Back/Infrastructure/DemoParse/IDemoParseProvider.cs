using System;
using System.Threading.Tasks;
using DataLuna.Back.Common.DemoParserProxy;

namespace DataLuna.Back.Infrastructure.DemoParse
{
    public interface IDemoParseProvider
    {
        Task<GetStatusResponse[]> GetDemosStatus();
        Task<PreParseResponse[]> PreParseDemo(PreParseCommand command);
        Task<DemoParseResponse> ParseDemo(DemoParseCommand command);
    }
}