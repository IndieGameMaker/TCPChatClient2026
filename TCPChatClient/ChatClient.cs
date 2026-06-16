using System.Net.Sockets;

namespace TCPChatClient;

public class ChatClient : IDisposable
{
    // TCP 클라이언트 소켓 선언
    private TcpClient? _tcpClient;
    // 네트워크 스트림
    private NetworkStream? _stream;
    private StreamReader? _reader;
    private StreamWriter? _writer;
    
    public void Dispose()
    {
        // TODO release managed resources here
    }
}
