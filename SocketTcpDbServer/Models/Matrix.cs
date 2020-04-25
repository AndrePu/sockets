namespace SocketTcpDbServer.Models
{
    public class Matrix
    {
        public string Name { get; set; }
        public string Data { get; set; }
        public Matrix() { }
        public Matrix(string name, string data)
        {
            Name = name;
            Data = data;
        }
    }
}
