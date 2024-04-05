let controlPannel = document.querySelector('.control-pannel');
let dialogPannel = document.querySelector('.dialog-pannel');
let prodList = document.querySelector('.prod-list');

function displayProducts() {
    if (window.innerWidth < 800) {
        prodList.style.gridTemplateColumns = '250px';
    } else {
        prodList.style.gridTemplateColumns = '250px 250px 250px';
    }
}

displayProducts();

function initControlPannel(){

    let width = window.innerWidth;

    if(width > 1800){

        controlPannel.style.gridTemplateColumns = '250px 250px 250px 250px 250px';
    }

    if(width > 1500 && width < 1800){

        controlPannel.style.gridTemplateColumns = '250px 250px 250px 250px';

    }

    if(width > 1200 && width < 1500){

        controlPannel.style.gridTemplateColumns = '250px 250px 250px';

    }

    if(width > 900 && width < 1200){

        controlPannel.style.gridTemplateColumns = '250px 250px';

    }

    if(width < 900){

        controlPannel.style.gridTemplateColumns = '250px';

    }

}

function initIpPannel(){

    let ipPannelWidth = window.innerWidth;

    if(ipPannelWidth > 970){

        document.querySelector('.v-header').style.display = 'grid';

        document.querySelectorAll('.visitor').forEach(v => {
            v.style.gridTemplateColumns = '200px 250px 200px 200px';
        });
    }

    if(ipPannelWidth <= 970){

        document.querySelector('.v-header').style.display = 'none';

        document.querySelectorAll('.visitor').forEach(v => {
            v.style.gridTemplateColumns = '250px';
        });

    }

}

function initDialogPannel(){

    let winSize = window.innerWidth;

    if(winSize > 850){
        dialogPannel.style.width = '40%'
    }

    if(winSize <  850){
        dialogPannel.style.width = '80%'
    }
}


initControlPannel();

initIpPannel();

initDialogPannel();

window.addEventListener('resize', () => {

    initIpPannel();

    initControlPannel();

    initDialogPannel();

    displayProducts();
});

document.querySelector('.for-orders').addEventListener('click', () => {

    document.querySelector('.for-orders').style.boxShadow = '0 0 15px white';

    Array.from(document.querySelectorAll('.control-element')).forEach(p => {
        if (!p.classList.contains('for-orders')) {
            p.style.boxShadow = 'none';
        }
    });

    document.querySelector('.order-space').style.display = 'flex';

    Array.from(document.querySelectorAll('.part')).forEach(p => {
        if (!p.classList.contains('order-space')) {
            p.style.display = 'none';
        }
    });

    window.scrollBy({
        top: 1000,
        left: 0,
        behavior: "smooth",
    });

});

document.querySelector('.for-visitors').addEventListener('click', () => {

    document.querySelector('.for-visitors').style.boxShadow = '0 0 15px white';

    Array.from(document.querySelectorAll('.control-element')).forEach(p => {
        if (!p.classList.contains('for-visitors')) {
            p.style.boxShadow = 'none';
        }
    });

    document.querySelector('.visitors-pannel').style.display = 'flex';

    Array.from(document.querySelectorAll('.part')).forEach(p => {
        if (!p.classList.contains('visitors-pannel')) {
            p.style.display = 'none';
        }
    });

    window.scrollBy({
        top: 1000,
        left: 0,
        behavior: "smooth",
    });

});

document.querySelector('.for-goods').addEventListener('click', () => {

    document.querySelector('.for-goods').style.boxShadow = '0 0 15px white';

    Array.from(document.querySelectorAll('.control-element')).forEach(p => {
        if (!p.classList.contains('for-goods')) {
            p.style.boxShadow = 'none';
        }
    });

    document.querySelector('.product-space').style.display = 'block';

    Array.from(document.querySelectorAll('.part')).forEach(p => {
        if (!p.classList.contains('product-space')) {
            p.style.display = 'none';
        }
    });

    window.scrollBy({
        top: 1000,
        left: 0,
        behavior: "smooth",
    });

});

document.querySelector('.for-messages').addEventListener('click', () => {

    document.querySelector('.for-messages').style.boxShadow = '0 0 15px white';

    Array.from(document.querySelectorAll('.control-element')).forEach(p => {
        if (!p.classList.contains('for-messages')) {
            p.style.boxShadow = 'none';
        }
    });

    document.querySelector('.dialogs-space').style.display = 'flex';

    Array.from(document.querySelectorAll('.part')).forEach(p => {
        if (!p.classList.contains('dialogs-space')) {
            p.style.display = 'none';
        }
    });

    window.scrollBy({
        top: 1000,
        left: 0,
        behavior: "smooth",
    });

});