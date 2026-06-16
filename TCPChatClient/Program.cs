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
        const string SERVER_IP = "192.168.0.149";
        const int SERVER_PORT = 7777;
        
        Console.Clear();
        Console.WriteLine("================== TCP 채팅 클라이언트 ==================");

        using var client = new ChatClient(SERVER_IP, SERVER_PORT);

        try
        {
            // 서버 연결
            await client.ConnectServerAsync();
            
            // 메시지 수신 메서드 시작(백그라운드 스레드)
            _ = Task.Run(client.ReceiveMessageAsync);
            
            // 사용자 입력 루프
            Console.WriteLine("메시지를 입력하세요. (종료: exit 입력)");
            Console.WriteLine("===============================");

            while (client.IsConnected)
            {
                // 사용자 메시지 입력 받기
                string? input = Console.ReadLine();
                
                if (string.IsNullOrEmpty(input))  continue;
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("채팅을 종료합니다...");
                    break;
                }
                
                // 서버에 메시지 전송
                await client.SendMessageAsync(input);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"[접속오류] {e.Message}");
        }
    }
}