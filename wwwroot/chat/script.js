let chatter = document.querySelector('.chat-pannel');

function initChat() {
    let w = window.innerWidth;

    if (w >= 900) {
        chatter.style.width = '40%';
    } else {
        chatter.style.width = '80%';
    }
}

initChat();

window.addEventListener('resize', () => {
    initChat();
})