let signPannel = document.querySelector('.signing-pannel');
let button = document.querySelector('.btn');
let inputs = document.querySelectorAll('input');

function initPannelSize(){

    if(window.innerWidth < 1273 && window.innerWidth > 650){
        signPannel.style.width = '40%';
        signPannel.style.overflow = 'visible';
        document.body.style.paddingTop = '100px';
    }

    if(window.innerWidth > 1273){
        signPannel.style.width = '20%';
        signPannel.style.overflow = 'visible';
        document.body.style.paddingTop = '100px';
    }

    if(window.innerWidth < 670 && window.innerWidth > 450){
        signPannel.style.width = '60%';
        signPannel.style.overflow = 'visible';
        document.body.style.paddingTop = '100px';
    }

    if(window.innerWidth < 450){
        signPannel.style.width = '98%';
        //signPannel.style.overflow = 'hidden';
        document.body.style.paddingTop = '100px';
    }
}

initPannelSize();

window.addEventListener('resize', ()=>{

    initPannelSize();

});

inputs.forEach(i=>{
    i.addEventListener('focus', ()=>{


    });
});

button.addEventListener('mousedown', ()=>{


});

