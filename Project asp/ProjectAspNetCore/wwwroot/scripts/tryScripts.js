
function OnMessageAdmin(message,userName) {
    var UserName = userName;
    var Message = message;
    var sendTime = "";
    connection.invoke("MessageAll", UserName, Message, sendTime);
}