using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace Lab_2.Handlers
{
    public class WebSocketHandler : Handler
    {
        private WebSocket webSocket;
        
        public override void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
                context.AcceptWebSocketRequest(WebSocketRequest);
        }
        
        private async Task WebSocketRequest(AspNetWebSocketContext context)
        {
            webSocket = context.WebSocket;
            while (webSocket.State == WebSocketState.Open)
            {
                Thread.Sleep(2000);
                DateTime currentTime = DateTime.Now;
                string str = currentTime.Hour + ":" + currentTime.Minute + ":" + currentTime.Second;
                await Send(str);
            }
        }

        private async Task Send(string date)
        {
            var sendBuffer = new ArraySegment<byte>(System.Text.Encoding.ASCII.GetBytes(date));
            await webSocket.SendAsync(sendBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}