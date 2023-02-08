// Задание 1

function СalcCircle(radius){
    let S = Math.PI * Math.pow(radius,2);
    let D = 2 * radius;
    let P = 2 * Math.PI * radius;

    alert(`Площадь = ${S}` + `\nДиаметр = ${D}` + `\nДлина окружности = ${P}`);
}

let userRadius = prompt("Введите радиус круга: ", "");

СalcCircle(userRadius);

// Задание 2

function StartShoping(){
    let userWallet = prompt("Введите количество средсв на карте", "");

    if(Number(userWallet) == NaN || Number(userWallet) < 0) userWallet = 0;

    let oldWallet = userWallet;

    while(true){
        let cost = prompt("Баланс: " + userWallet +"\nВведите стоимость товара", "");

        if(Number(cost) == NaN || Number(cost) < 0) buffer = 0;
        else if(cost == 0) break;

        if((userWallet - cost) >= 0) userWallet -= cost;
        else if((userWallet - cost) < 0) alert("Недостаточно средств для покупки данного товара");
    }
    alert("Ваш заказ на сумму " + (oldWallet - userWallet) + " принят");
}

StartShoping();

// Задание 3

function getParams( second, userParm,first = 1){
    return `${first} ${second} ${userParm}`;
}

alert( getParams( 2, prompt("Введите параметр", "")) );

// Задание 4

function getCountOfStudents(){
    let countOfStudents = 0;

    while(true){
        let studentName = prompt("Введите имя студента: ", "");
        
        if(studentName == null || studentName == 0) break;

        countOfStudents += 1;
    }
    
    return countOfStudents;
}

alert("Количество присутствующих студентов - " + getCountOfStudents());

// Задание 5

function params1(a,b){
    if(a == b) return (a + b) * 2;
    else return a * b;
}

let params = function(a, b){
    if(a == b) return (a + b) * 2;
    else return a * b;
}(5,10);
alert(params);

// Задание 6

let variants = Math.pow(26, 5) * Math.pow(10, 3);
let seconds = variants * 3;

let minuts = 0;
let hours = 0;
let days = 0;
let month = 0; 
let years = 0;

while((seconds - 60) >= 0){
    if((seconds - 31536000) >= 0){
        seconds -= 31536000;
        years += 1;
        continue;
    }
    if((seconds - 2592000) >= 0){
        seconds -= 2592000;
        month += 1;
        continue;
    }
    if((seconds - 86400) >= 0){
        seconds -= 86400;
        days += 1;
        continue;
    }
    if((seconds - 3600) >= 0){
        seconds -= 3600;
        hours += 1;
        continue;
    }
    seconds -= 60;
    minuts += 1;
}

alert(`${years} лет ${month} месяцев ${days} дней ${hours} часов ${minuts} минут ${seconds} секунд`)

// Задание 7

let getParam = (first = 1, second, userParm) => `${first} ${second} ${userParm}`;

alert( getParam(3, 2, prompt("Введите параметр", "")) );