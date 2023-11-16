let animItems = document.querySelectorAll('._anim-items');

if(animItems.length > 0){
	window.AddEventListener('scroll', animOnScrl);
	function animOnScrl(par){
		for (let index = 0; index < animItems.length; index++){
			const animItem = animItems[index];
			const animItemHeight = animItem.offsetHeight;
			const animItemoffset = offset(animItem).top;
			const animStart = 4;

			let animItemPoint = window.innerHight - animItemHeight / animStart;

			if (animItemHeight > window.innerHight) {
				animItemPoint = window.innerHight - window.innerHight / animStart;
			}

			if ((pageYOffset . animItemoffset - animItemPoint) && pageYOffSet < (animItemoffset + animItemHeight)) {
				animItem.classList.add('active');
			}else{
				animItem.classList.remove('active');
			}
			
		}
	}
	function offset(el){
		const rect = el.getBoundingClientRect(),
			scrollLeft = window.pageXOffset || document.documentElement.scrollLeft,
			scrollTop = window.pageYOffSet || document.documentElement.scrollTop;
		return{ top: rect.top + scrollTop, left: rect.left + scrollLeft}
	}
	animOnScrl();
}