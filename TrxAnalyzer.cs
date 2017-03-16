using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace trx_reader
{
    internal class TrxAnalyzer
    {
        private readonly XNamespace _ns = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010";
        private readonly XDocument _trx;

        public TrxAnalyzer(XDocument trxDocument)
        {
            _trx = trxDocument;
        }

        public IEnumerable<TrxOutcomeSummary> GetSummary()
        {
            return _trx.Descendants(fq("UnitTestResult"))
                        .GroupBy(elm => elm.Attribute("outcome").Value)
                        .Select(g => new TrxOutcomeSummary(g.Key, g.Count()));
        }

        public IEnumerable<TrxFailedTest> GetFailed()
        {
            var failedTests = _trx.Descendants(fq("UnitTestResult"))
                        .Where(r => r.Attribute("outcome").Value.ToLower() == "failed");

            return failedTests.Descendants(fq("ErrorInfo"))
                .Select(e => new TrxFailedTest(
                    e.Element(fq("Message")).Value, 
                    e.Element(fq("StackTrace")).Value));
        }

        private XName fq(string tagName)
        {
            return _ns.GetName(tagName);
        }
    }
}
