//task 1
window.onload = function ()
{
var canvas = document.getElementById('smile');
var canvas1 = document.getElementById('smile');
var canvas2 = document.getElementById('smile');
var rect = canvas.getContext('2d');
var circle = canvas1.getContext('2d');
var triangle = canvas2.getContext('2d'); 

let RECT ={
R:rect.fillStyle = 'yellow',
R2:rect.fillRect(100, 25,100, 100),
R3:rect.fill(),
};

let CIRCLE ={
C:circle.beginPath(),
C:circle.arc(275,75,50,0,Math.PI*2,true),
C:circle.stroke(),
};

let TRIANGLE ={
T:triangle.moveTo(400, 25),
T:triangle.lineTo(450, 125),
T:triangle.lineTo(350, 125),
T:triangle.lineTo(400, 25),
T:triangle.lineTo(400,125),
T:triangle.stroke(),
};

let style ={
   widthX:50,
   widthY:50,
   backround: 'green',
   lineTo1_1:400,
   lineTo1_2:225,
   lineTo2_1:390,
   lineTo2_2:165,
   lineTo2_3:225,
}

let RECT2 = Object.create(Object.getPrototypeOf(RECT), Object.getOwnPropertyDescriptors(RECT),
   rect.fillRect(120, 150,
   style.widthX, 
   style.widthY));
let CIRCLE2 = Object.create(Object.getPrototypeOf(CIRCLE), Object.getOwnPropertyDescriptors(CIRCLE),
   circle.beginPath(),
   circle.arc(275,200,50,0,Math.PI*2,true),
   circle.stroke(),
   circle.fillStyle = style.backround,
   circle.fill());
let TRIANGLE2 = Object.create(Object.getPrototypeOf(TRIANGLE), Object.getOwnPropertyDescriptors(TRIANGLE),
   triangle.moveTo(400,150),
   triangle.lineTo(350,225),
   triangle.lineTo(450,225),
   triangle.lineTo(400,150),
   triangle.lineTo(style.lineTo1_1,style.lineTo1_2),
   triangle.moveTo(390,165),
   triangle.lineTo(390,225),
   triangle.moveTo(410,165),
   triangle.lineTo(410,225),
   triangle.stroke());

  
console.log("зеленый круг(цвет):",style.backround);
console.log("Координаты центральной линии:" + "(",style.lineTo1_1,":",150,")",";","(",style.lineTo1_1,":",style.lineTo1_2,")",style.lineTo2_1,style.lineTo2_2,style.lineTo2_3);
}