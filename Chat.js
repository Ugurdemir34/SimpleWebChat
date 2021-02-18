
"use strict"

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();




var userid = $('input:hidden[name=userid]').val();
let message = $(".type_msg").val();

var otheruserid = $('input:hidden[name=otheruserid]').val();
connection.on("ReceiveMessage", function (delivereddate, messagecontent, messagefrom, messageto) {


    console.log(messagecontent + "-" + delivereddate + "-" + messagefrom + "-" + messageto);
   
    if (userid === messageto)
    {
        

        var state = "msg_cotainer";
        var content = "justify-content-start";
        var time = "msg_time";
        $('.msg_card_body').append("<div class='d-flex " + content + " mb-4' ><div class='" + state + "'>" + messagecontent + "<span class='" + time + "' style='color:black'>" + delivereddate + "</span></div></div > ");
        //<div class='img_cont_msg'> <img src='https://static.turbosquid.com/Preview/001292/481/WV/_D.jpg' class='rounded-circle user_img_msg'></div>

    }
    else {
       
        var state = "msg_cotainer_send";
        var content = "justify-content-end";
        var time = "msg_time_send";
        $('.msg_card_body').append("<div class='d-flex " + content + " mb-4' ><div class'" + state + "'>" + messagecontent + "<span class='" + time + "' style='color:black'>" + delivereddate + "</span></div ></div > ");

    }
});

$(".send_btn").on("click", function (event) {
    message = $(".type_msg").val();
    if (message.length > 0) {
       
        let date = new Date($.now());
        var datetime = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate() + " " + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds()
        var showtime = date.getHours() + ":" + date.getMinutes();

        var state = "msg_cotainer_send";
        var content = "justify-content-end";
        var time = "msg_time_send";
        $('.msg_card_body').append("<div class='d-flex " + content + " mb-4' ><div class='" + state + "'>" + message + "<span class='" + time + "' style='color:black'>" + showtime + "</span></div></div > ");

        connection.invoke("SendMessage", datetime, message, userid, otheruserid).catch(function (err) {
            return console.log(err);
        });

        event.preventDefault();
        $(".type_msg").val("");
    }
   
  

});


connection.start().then(function (done) {


    connection.invoke('Connect', userid).catch(function (err) {
        return console.log(err);
    }).then(function () {
      
    })


}).catch(function (err) {
    return alert(err.toString());
});

