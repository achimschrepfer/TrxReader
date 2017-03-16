namespace trx_reader
{
    public class TrxOutcomeSummary
    {
        public TrxOutcomeSummary(string outcome, int numberOfTests)
        {
            this.Outcome = outcome;
            this.NumberOfTests = numberOfTests;
        }
        public string Outcome { get; private set; }
        public int NumberOfTests { get; private set; }
    }
}
