namespace trx_reader
{
    public class TrxFailedTest
    {
        public TrxFailedTest(string message, string stackTrace)
        {
            this.Message = message;
            this.StackTrace = stackTrace;

        }
        public string Message { get; private set; }
        public string StackTrace { get; private set; }
    }
}
