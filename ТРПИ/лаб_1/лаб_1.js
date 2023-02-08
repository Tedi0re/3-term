//1
function pow(x, n)
{
    let result = 1;
    for(var i = 0; i < n; i++) {result*=x;}
    return result;
}

x = prompt("x?",'')
n = prompt("n?",'')

if(n < 0)
{
    alert('Степень ' + n +' не поддерживается, введите целую степень, большую 0')
}
else
{
    alert(pow(x,n))
}
//2
let userName = "Andrey";
let city = "Minsk";
let date = "25.02.2004";
let red ;
let answer;
let inf = 1/0;
let a = 532;
let P = "120mm";
alert('Введенные данные неверны')
//3
let ab = 5;
let name = "Name";
let i = 0;
let double = 0.23;
let result = 1/0;
let answera = true;
let no = null;
//4
let A_1 = 45;
let A_2 = 21;
let P_A = (21+45)*2 + 'mm';
alert(P_A)
//5
let B = (A_1/5)*parseInt((A_2/5))
//6
let i_i = 2;
let ac = ++i_i;
let b = i_i++;
//7
alert("Привет">"привет")
alert("Привет">"Пока")
alert(45>"53")
alert(false>3)
alert(true>"3")
alert(3>"5mm")
//8
alert('Введенные данные неверны')
//9
answer = prompt("Секрет?", '')
if(answer === 'да')
{
    alert('да')
}
else
{
    alert('нет')
}
//10
login = prompt("Вход в личный кабинет \nВведите логин",'')
password = prompt("Вход в личный кабинет \nВведите пароль",'')
if(login == userName && password == 123)
{
    alert("Вход в личный кабинет выполнен")
}
else
{
    alert("Неверно введены данные")
}
//11
let exam_ru = 1;
let exam_math = 1;
let exam_En = 1;

if( exam_En && exam_math && exam_ru)
{
    alert('Студента перведут на следующий курс')
}
else if(exam_En || exam_math || exam_ru)
{
    alert('Студент идет на пересдачу')
}
else
{
    alert('Студента отчислят')
}
//12
let number1, number2;
number1 = prompt("Введите первое число",'');
number2 = prompt("Введите второе число",'');
alert(number1+number2);
//13
alert(true + true)
alert(0 + "5")
alert(5 + "mm")
alert(8/Infinity)
alert(9 *"\n9")
alert(null - 1)
alert("5" - 2)
alert("5px" - 3)
alert(true - 3)
alert(7||0)
//14
let m = [1,2,3,4,5,6,7,8,9,10]
for(let i = 0; i<10;i++)
{
    if(m[i]%2==0)
    {
        m[i]+=2;
    }
    else
    {
        m[i]+="mm";
    }
    alert(m[i])
}
//15
while(true)
{
    let c = prompt("c?",'')
    if(c<100) break;
}
//16
let day = prompt("Введите день недели",'')
switch (day) {
    case "1":
        alert('понедельник')
        break;
        case "2":
        alert('вторник')
        break;
        case "3":
        alert('среда')
        break;
        case "4":
        alert('четверг')
        break;
        case "5":
        alert('пятница')
        break;
        case "6":
        alert('суббота')
        break;
        case "7":
        alert('воскресенье')
        break;

    default:
        alert('нет такого дня недели')
        break;
}

