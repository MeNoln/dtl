using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLuna.Back.Common.DemoParserProxy;

namespace DataLuna.Back.Infrastructure.DemoParse
{
    public interface IDemoParseProvider
    {
        Task<GetStatusResponse[]> GetDemosStatus();
        Task<PreParseResponse[]> PreParseDemo(PreParseCommand command);
        Task<List<DemoParseResponse>> ParseDemo(DemoParseCommand command);
    }
}