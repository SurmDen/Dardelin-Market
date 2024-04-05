
let mainSection = document.querySelector('.s-first');

function initSection(){
    if(window.innerWidth < 550){
        mainSection.style.flexDirection = 'column';

        mainSection.style.alignItems = 'center';
    }
    else{
        mainSection.style.flexDirection = 'row';

        mainSection.style.alignItems = 'flex-start';
    }
}

initSection();

window.addEventListener('resize', () => {
    initSection();
});

setTimeout(3000, () => {
    document.querySelector('center').style.display = 'none';
});