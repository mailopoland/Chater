$(function () {
    //containers ids:
    var allUsers = "#UserList";
    var logOutBut = "#logOutMe";
    var msgDisplay = "#AllMessages";
    var msgSend = "#SendMsg";
    var msgTxt = "#CurMessage";
    //parms
    var logOutPage = "http://" + window.location.host + "/LogOut";
    //--- end of configuration variables
    var manageChat = $.connection.jsRuner;

    manageChat.client.addUser = function (loginName) {
        $(allUsers).append(loginName + "<br>");
    }
    manageChat.client.removeUser = function (loginName) {
        var regex = new RegExp(loginName + " *<br>");
        $(allUsers).html($(allUsers).html().replace(regex, ""));
    }
    //because it is hard to do now programicly redirect
    manageChat.client.logOut = function () {
        window.location.replace(logOutPage);
    }

    manageChat.client.test = function (txt) {
        alert(txt);
    }

    manageChat.client.displayMsg = function (user, txt) {
        $(msgDisplay).append("<b>" + user + "</b>: " + txt + "<br>");
    }



    $.connection.hub.start()
        .done(function () {
            manageChat.server.logIn();

            $(msgSend).click(function () {
                manageChat.server.sendMessage($(msgTxt).val());
                $(msgTxt).val('').focus();
            });

            $(logOutBut).click(function () {
                manageChat.server.logOutAll();
            });

            $(window).on('beforeunload ', function () {
               manageChat.server.logOut();
            });
        })
        .fail(function () {
            alert("Error. Please try again.");
        })
    });
