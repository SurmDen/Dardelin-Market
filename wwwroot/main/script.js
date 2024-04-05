let header = document.querySelector('header');
let firstSection = document.querySelector('.first-section');
let menu = document.querySelector('.menu');
let mainPart = document.querySelector('.main-part');
let goodLists = document.querySelector('.good-list');
let goods = Array.from(document.querySelectorAll('.good'));
let chatButton = document.querySelector('.chat');
let chatPannel = document.querySelector('.chat-pannel');
let searchInp = document.querySelector('.search-input');

function initCategories(){
    if(window.innerWidth < 1075){
        goodLists.style.gridTemplateColumns = "250px"
    }
    else{
        goodLists.style.gridTemplateColumns = "250px 250px 250px"
    }
}

function displayElements(){
    if(window.innerWidth < 870 && window.innerWidth > 570){
        menu.style.width = '45%';
        mainPart.style.width = '55%';
        firstSection.style.flexDirection = 'row';
        initMainPartsLeftMargin();
        initMenuHeight();
        menu.style.position = 'fixed';
        menu.style.justifyContent = 'flex-start';
    }

    if(window.innerWidth > 870){
        menu.style.width = '20%';
        mainPart.style.width = '80%';
        firstSection.style.flexDirection = 'row';
        initMainPartsLeftMargin();
        initMenuHeight();
        menu.style.position = 'fixed';
        menu.style.justifyContent = 'flex-start';
    }

    if(window.innerWidth < 570){
        menu.style.width = '100%';
        mainPart.style.width = '100%';
        firstSection.style.flexDirection = 'column';
        mainPart.style.marginLeft = 0 + 'px';
        menu.style.position = 'initial';
        menu.style.justifyContent = 'center';
        menu.style.height = 'auto';
    }
}

function initTopPadding(){

    let headersPadding = header.getBoundingClientRect().top;

    let headersHeight = header.clientHeight;

    let totalPadding = headersHeight + headersPadding;

    firstSection.style.paddingTop = totalPadding+'px';
}

function initMenuHeight(){

    let headersPadding = header.getBoundingClientRect().top;

    let headersHeight = header.clientHeight;

    let totalPadding = headersHeight + headersPadding;

    let windowHeight = window.innerHeight;

    menu.style.height = windowHeight - totalPadding + 'px';
}

function initMainPartsLeftMargin(){

    let menuWidth = menu.clientWidth;

    mainPart.style.marginLeft = menuWidth + 20 + 'px';
}

function initTopBar(){

    if(window.innerWidth < 940){
        header.style.flexDirection = 'column';
    }
    else{
        header.style.flexDirection = 'row';
    }
}

function displayChatButton(){

    let winH = window.innerHeight;

    console.log(winH);

    chatButton.style.top = winH - 100 + 'px';

    chatButton.style.right = '30px';
}

initTopBar();

displayElements();

initTopPadding();

initCategories();

displayChatButton();

window.addEventListener('resize', ()=>{

    initTopBar();

    displayElements();

    initTopPadding();

    initCategories();

    displayChatButton();

});

goods.forEach(g=>{

    g.addEventListener('mouseover', ()=>{

        g.firstElementChild.style.width = '100px';

        g.firstElementChild.style.height = 'auto';

        g.lastElementChild.style.fontSize = '40px';

    });

    g.addEventListener('mouseout', ()=>{

        g.firstElementChild.style.width = '60px';

        g.firstElementChild.style.height = 'auto';

        g.lastElementChild.style.fontSize = '30px';

    });
});

chatButton.addEventListener('click', ()=>{
    chatPannel.style.display = 'flex';
});

document.querySelector('.closer').addEventListener('click', ()=>{
    chatPannel.style.display = 'none';
});

searchInp.addEventListener('focus', ()=>{

    document.querySelector('.h-inp-group button').disabled = false;

    if(searchInp.value === 'поиск по товарам'){
        searchInp.value = '';
    }
})

document.querySelector('.h-inp-group button').addEventListener('mousedown', (e)=>{
    if(searchInp.value === '' || searchInp.value === 'поиск по товарам'){
        document.querySelector('.h-inp-group button').disabled = true;
    }
});

setTimeout(3000, () => {
    document.querySelector('center').style.display = 'none';
});



