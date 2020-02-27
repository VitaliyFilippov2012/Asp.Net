let textArea;
let webSocket = null;
let startButton;
let stopButton;

window.onload = function() {
    textArea = document.getElementById('text-area');
    startButton = document.getElementById('start-button');
    stopButton = document.getElementById('stop-button');
}

function startClick() {
    if (webSocket == null) {
        webSocket = new WebSocket("ws://localhost:55444/date.websocket");
        webSocket.onmessage = function(date) {
            textArea.value += date.data + "\n";
        }
    }
}

function stopClick() {
    if (webSocket != null) {
        webSocket.close();
        webSocket = null;
    }
}