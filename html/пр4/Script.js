// function loading(a) {
//     var a = 0;
//     var i = 5;
//     const container = document.querySelector('.container');

//     while (a < i) {
//         a++;
//       setTimeout(() => {}, 1000);
      
//     }

//     container.classList.add('show');
//   }
  

function loading() {
    var b = 0;
    var i = 5;
    const container = document.querySelector('.container');
  
  
    while (b < i) {
        setTimeout(() => {  }, 1000);
        b++;
    }
    container.classList.add('show');
  }