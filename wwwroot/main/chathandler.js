let hubConnection = new signalR.HubConnectionBuilder().withUrl('/chat').build();

document.querySelector('.send-group button').addEventListener('click', () => {

    let message = document.querySelector('.send-group input').value;

    hubConnection.invoke('Send', message);

    document.querySelector('.send-group input').value = '';
});

hubConnection.on('Receive', function (message, email) {

    let currentEmail = document.querySelector('.current-email').value;

    let messageBox = document.querySelector('.message-box');

    let preMessage = document.createElement('div');

    let mess = document.createElement('div');

    mess.textContent = message;

    preMessage.appendChild(mess);

    preMessage.classList.add('mess');

    messageBox.appendChild(preMessage);


    if (email == currentEmail) {

        preMessage.classList.add('user');

        mess.classList.add('user-context');
    }
    else
    {

        preMessage.classList.add('admin');

        mess.classList.add('admin-context');
    }

});

hubConnection.start();