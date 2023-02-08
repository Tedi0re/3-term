let url = `https://pngimg.com/uploads/laptop/small/laptop_PNG101830.png`;
let productMain = document.querySelector('.card');
let productContent = document.querySelector('.content');

let button = document.createElement('button');

class Button {
	constructor(w, h, bg, textContent) {
		this.w = w;
		this.h = h;
		this.bg = bg;
		this.textContent = textContent;
	}
	addButton() {
		button.textContent = this.textContent;
		button.style.width = this.w;
		button.style.height = this.h;
		button.style.backgroundColor = this.bg;
		productContent.append(button);
	}
	deleteBtn() {
		button.addEventListener('click', function () {
			button.style.display = 'none';
		});
	}
}
let btn = new Button('80px', '35px', 'rgb(0, 132, 255)', 'Корзина');
btn.addButton();
btn.deleteBtn();

class Products {
	constructor(url, description, price, button) {
		this.url = url;
		this.description = description;
		this.price = price;
		this.button = button;
	}

	addItem() {
		let div = document.createElement('div');
		div.classList.add('card__item');
		let button = document.createElement('button');
		button.classList.add('card__button');
		button.innerHTML = 'В Корзину';



		let description = document.createElement('h4');
		description.textContent = this.description;
		let price = document.createElement('p');
		price.textContent = this.price;

		let img = new Image();
		img.src = url;
		div.append(img);
		div.append(description);
		div.append(price);
		div.append(button);
		productMain.append(div);
		button.addEventListener('click', () => {
			div.textContent = ''
		  })
	}
}

let productOne = new Products(url, 'MacBook', '190$', btn);
productOne.addItem();
productOne.addItem();
productOne.addItem();
productOne.addItem();
productOne.addItem();
productOne.addItem();
productOne.addItem();
productOne.addItem();
productOne.addItem();
productOne.addItem();
productOne.addItem();
productOne.addItem();
productOne.addItem();
