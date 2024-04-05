function displayProducts() {

    let prodList = document.querySelector('.prod-list');

    if (window.innerWidth > 1400)
    {
        prodList.style.gridTemplateColumns = '250px 250px 250px 250px';

        console.log('big');

        document.querySelector('.sale-banner').style.width = 1090 + 'px';
    }

    if (window.innerWidth > 1200 && window.innerWidth < 1400) {
        prodList.style.gridTemplateColumns = '250px 250px 250px';

        console.log('middle');

        document.querySelector('.sale-banner').style.width = 810 + 'px';
    }

    if (window.innerWidth > 700 && window.innerWidth < 1200) {
        prodList.style.gridTemplateColumns = '250px 250px';

        console.log('just small');

        document.querySelector('.sale-banner').style.width = 530 + 'px';
    }

    if (window.innerWidth < 700) {
        prodList.style.gridTemplateColumns = '250px';

        console.log('small');

        document.querySelector('.sale-banner').style.width = 250 + 'px';
    }
}

displayProducts();

window.addEventListener('resize', () => {

    displayProducts();
});

document.querySelector('.cat-title').addEventListener('click', ()=>{

    let isDisp = document.querySelector('.cat-list').getAttribute('disp');

    if(isDisp === 'true'){

        document.querySelector('.cat-list').style.display = 'none';

        document.querySelector('.cat-list').setAttribute('disp', false);

        document.querySelector('.arrow').style.transform = 'rotate(0deg)';
    }
    else{

        document.querySelector('.cat-list').style.display = 'block';

        document.querySelector('.cat-list').setAttribute('disp', true);
        
        document.querySelector('.arrow').style.transform = 'rotate(180deg)';
    }

});

Array.from(document.querySelectorAll('.category')).forEach(c=>{
    c.addEventListener('click', ()=>{

        document.querySelector('.cat-title span').textContent = c.textContent;

        document.querySelector('.cat-list').style.display = 'none';

        document.querySelector('.cat-list').setAttribute('disp', false);

        document.querySelector('.arrow').style.transform = 'rotate(0deg)';

        Array.from(document.querySelectorAll('.product')).forEach(p=>{
            if (p.getAttribute('cat') !== c.getAttribute('cat')) {
                p.style.display = 'none';
            } else {
                p.style.display = 'flex'
            }
        });

    });
});

document.querySelector('.all').addEventListener('click', () => {
    Array.from(document.querySelectorAll('.product')).forEach(p => {
        p.style.display = 'flex';
    });
});
