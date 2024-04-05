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

        if(i.value === 'Имя'){

            i.value = '';

        }

        i.style.boxShadow = 'none';

        button.disabled = false;

        if(i.value === 'Пароль'){

            i.setAttribute('type', 'password');

            i.value = '';

        }
    });
});

button.addEventListener('mousedown', ()=>{

    inputs.forEach(i=>{
        
        if(i.value === '' || i.value === 'Имя' || i.value === 'Пароль'){

            i.style.boxShadow = '0 0 8px orange';

            button.disabled = true;

            return;
        }
    });

});

setTimeout(3000, () => {
    document.querySelector('center').style.display = 'none';
});

