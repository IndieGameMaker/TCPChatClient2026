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
    
    // 연결 여부
    private bool _isConnected;
    // 리소스 해제여부
    private bool _isDisposed;
    
    // 서버 IP, Port
    private readonly string _serverIp;
    private readonly int _serverPort;
    
    // 연결 여부 프로퍼티
    public bool IsConnected => _isConnected && !_isDisposed;
    
    public void Dispose()
    {
        // TODO release managed resources here
    }
}
