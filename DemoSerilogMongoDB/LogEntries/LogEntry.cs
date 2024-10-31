namespace DemoSerilogMongoDB.LogEntries
{
	public class LogEntry
	{
        public string Message { get; set; }
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
    }
}
