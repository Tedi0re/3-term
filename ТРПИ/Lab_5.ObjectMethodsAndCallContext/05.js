
let products = {
	shoes: {
		boots: [{ id: 1, color: 'black', size: 25, cost: 1450 },{ id: 1.1, color: 'white', size: 25, cost: 150 },{ id: 1.2, color: 'yellow', size: 2, cost: 50 }],
		sneakers: [{ id: 3, color: 'black', size: 25, cost: 850 },{ id: 3.1, color: 'blue', size: 3, cost: 9850 },{ id: 3.2, color: 'black', size: 34, cost: 820 }],
		sandals: [{ id: 5, color: 'black', size: 39, cost: 950 },{ id: 3, color: 'black', size: 32, cost: 850 },{ id: 3, color: 'black', size: 25, cost: 850 }],
	},
};

let b = [];
let a = products.shoes;
for (let key in a) {
	for (let i = 0; i < a[key].length; i++) {
		b.push(a[key][i]);
	}
}
function filteredProductsByCostOrSize(products, category, value) {
	let filteredCategory = [];
	for (let elem of products) {
		if (elem[`${category}`] > value) {
			filteredCategory.push(elem);
		}
	}
	return filteredCategory;
}
let filterCostOrSize = filteredProductsByCostOrSize(b, 'size', 25);

console.log(filterCostOrSize);

function filteredProductsByColor(products, color) {
	let filteredColor = [];
	for (let elem of products) {
		if (elem['color'] === color) {
			filteredColor.push(elem);
		}
	}
	return filteredColor;
}
let filterColor = filteredProductsByColor(b, 'black');

console.log(filterColor);

class Product {
	
	setDiscount(value) {
		if(value <= 1) this.discount = value;
		else this.discount = 0;
		return this.discount	;	
	}

	getFinally(){
		return this.cost - (this.cost * this.discount);
	}

	constructor(id, color, size, cost, discount) {
	  this.id = id;
	  this.color = color;
	  this.size = size;
	  this.cost = cost;
	  this.discount = this.setDiscount(discount);
	}
	
}

 

let productComplete = new Product(
	filterColor[0]['id'],
	filterColor[0]['color'],
	filterColor[0]['size'],
	1000,
	0.2,
);



Object.defineProperties(productComplete, {
	id: { value: filterColor[0]['id'], writable: false },
	color: { value: filterColor[0]['color'], writable: false },
	size: { value: filterColor[0]['size'], writable: false },
});
Object.defineProperty(productComplete, 'id', {
	configurable: false,
})

console.log(productComplete);
console.log(productComplete.getFinally());


function iterator(obj) {
	let iterator = obj.shoes;
	for (let key in iterator) {
		console.log(`Наименование товара: ${key}`);
		for (let item of iterator[key]) {
			console.log(`
   Id: ${item['id']}
   Color: ${item['color']}
   Size: ${item['size']}
   Cost: ${item['cost']}`);
		}
	}
}
iterator(products);
