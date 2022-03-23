var chatBox = $("#ChatBox");
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub").build();


async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(async () => {
    await start();
});

// Start the connection.
start();


function showChatDialog() {
    chatBox.css("display", "block");
}

function Init() {

    setTimeout(showChatDialog, 1000);


    var NewMessageForm = $("#NewMessageForm");
    NewMessageForm.on("submit", function (e) {

        e.preventDefault();
        var message = e.target[0].value;
        e.target[0].value = '';
        sendMessage(message);
    });

}

function sendMessage(text) {
    connection.invoke('SendNewMessage', " بازدید کننده ", text);
}

$(document).ready(function () {
    Init();
});
