namespace SocketCommon.TransportModel
{
    public class OperationResult<T>
    {
        public OperationStatus Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
