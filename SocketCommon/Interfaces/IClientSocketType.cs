using SocketCommon.TransportModel;

namespace SocketCommon.Interfaces
{
    public interface IClientSocketType<T, S>
    {
        OperationResult<T> GetData(S inputData);
    }
}
