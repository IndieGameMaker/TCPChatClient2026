using System.Text;

namespace TCPChatClient;

class Program
{
    static async Task Main(string[] args)
    {
        // UTF-8 인코딩 설정
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        
        // 서버 IP, Port
        const string SERVER_IP = "127.0.0.1";
        const int SERVER_PORT = 7777;
        
        Console.Clear();
        Console.WriteLine("================== TCP 채팅 클라이언트 ==================");

        using var client = new ChatClient(SERVER_IP, SERVER_PORT);

        try
        {
            // 서버 연결
            await client.ConnectServerAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"[접속오류] {e.Message}");
        }
    }
}