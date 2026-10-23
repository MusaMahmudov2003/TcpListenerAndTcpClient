

using System.Net;
using System.Net.Sockets;
using System.Text;

int port = 5000;

//Socket socket = new Socket(
//    AddressFamily.InterNetwork,
//    SocketType.Stream,
//    ProtocolType.Tcp
//    );

//var endpoint = new IPEndPoint(IPAddress.Loopback, 5000);

//socket.Bind(endpoint);

//socket.Listen(10);

//socket.Connect(endpoint);

TcpListener listener = new TcpListener(IPAddress.Loopback, port);
listener.Start();

Console.WriteLine("Server started");
Console.WriteLine("Waiting...");
using var client = await listener.AcceptTcpClientAsync();

using var stream = client.GetStream();

byte[] buffer = new byte[1024];

var readedLength = await stream.ReadAsync(buffer);

var message = Encoding.UTF8.GetString(buffer, 0, readedLength);

Console.WriteLine($"Message from client:{message}");

var responseFromServer = "Server received message";

var responseToServerBytes = Encoding.UTF8.GetBytes(responseFromServer);

await stream.WriteAsync(responseToServerBytes, 0, responseToServerBytes.Length);


//int port = 5000;

//using TcpClient tcpClient = new TcpClient();

//IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Loopback, port);

//await tcpClient.ConnectAsync(iPEndPoint);

//using var stream = tcpClient.GetStream();

//string message = Console.ReadLine();

//var bytes = Encoding.UTF8.GetBytes(message);

//await stream.WriteAsync(bytes, 0, bytes.Length);

//var responseFromServerBytes = new byte[1024];

//var responseLength = await stream.ReadAsync(responseFromServerBytes);

//var responseFromServer = Encoding.UTF8.GetString(responseFromServerBytes, 0, responseLength);

//Console.WriteLine($"Response from server:{responseFromServer}");