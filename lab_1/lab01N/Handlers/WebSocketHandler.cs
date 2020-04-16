using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace lab01
{
    public class WebSocketHandler : HttpHandler
    {
        private WebSocket _webSocket;
        
        public override void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
                context.AcceptWebSocketRequest(WebSocketRequest);
        }
        
        private async Task WebSocketRequest(AspNetWebSocketContext context)
        {
            _webSocket = context.WebSocket;
            while (_webSocket.State == WebSocketState.Open)
            {
                Thread.Sleep(2000);
                var currentTime = DateTime.Now;
                var str = currentTime.Hour + ":" + currentTime.Minute + ":" + currentTime.Second;
                await Send(str);
            }
        }

        private async Task Send(string date)
        {
            var sendBuffer = new ArraySegment<byte>(System.Text.Encoding.ASCII.GetBytes(date));
            await _webSocket.SendAsync(sendBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}