let names = [];

function Task_1()
{
    let arg = prompt("Ведите аргументы через пробел","");
    let args = arg.split(' ');
    function print()
    {
        if(args.length < 3)
        {
            let str;
            for(let i = 0; i < args.length; i++)
            {
                str += args[i];
            }
            alert(args);
        }
        else if(args.length < 5)
        {
            let types = "";
            for(let i = 0; i < args.length; i++)
            {
                types += typeof(args[i]) + " ";
            }
            alert(types);
        }
        else if(args.length < 7) alert(args.length);
        else alert("Слишком много параметров");
    }
    print();
    names.push(print.name);
}

function Task_2()
{
    try//1
    {
        window.a1 = 2;
        alert("1. " + a1);
    }
   catch (e)
   {
        alert("Ошибка");
   }

   try//2
   {
    alert("2. " + a2);
    window.a2 = 2;
   }
   catch (e)
   {
        alert("Ошибка");
   }
    
    try//3
    {
        alert("3. " + a3);
        window.a3 = 2;
        let a3;
    }
    catch (e)
   {
        alert("Ошибка");
   }

    try//4
    {
        alert("4. " + a4);
        window.a4 = 2;
        var a4;
    
    }
    catch (e)
   {
        alert("Ошибка");
   }

    try//5
    {
        alert("5. " + a5);
        let a5 = 2;
    }
   catch (e)
   {
        alert("Ошибка");
   } 

    try//6
    {
        let a6 = 2;
        window.a6 = 3;
        alert("6. " + a6);
    } 
    catch (e)
    {
         alert("Ошибка");
    }

    try//7
    {
        var a7 = 2;
        window.a7 = 3;
        alert("7. " + window.a7);
    }
    catch (e)
   {
        alert("Ошибка");
   }
}

function Task_3()
{
    let s = 5;
    function sum()
    {
        alert(s)
    }
    sum();
    names.push(sum.name);
}

function Task_4_1()
{
    function makeCounter()
    {
        let currentCounter = 1;
        return function()
        {
            return currentCounter++;
        };
    }
    let counter = makeCounter();
    let counter1 = makeCounter();
    let counter3 = makeCounter();
    let counter4 = makeCounter();

    alert( counter());
    alert( counter1());
    alert( counter());
    alert( counter1());
    alert( counter());
    alert( counter1());
    alert( counter());
    alert( counter1());
    names.push(makeCounter.name);
}

function Task_4_2()
{
    let currentCounter = 1;

    function makeCounter()
    {
        return function()
        {
            return currentCounter++;
        };
    }

    let counter = makeCounter();
    let counter2 = makeCounter();

    alert(counter());
    alert(counter());

    alert(counter2());
    alert(counter2());

    names.push(makeCounter.name);
}

function Task_5()
{
    alert(Task_1.name + " " + 
    Task_2.name + " " + 
    Task_3.name + " " +
    Task_4_1.name + " " +
    Task_4_2.name)
    let str = "";
    for(let i = 0; i < names.length; i++)
    {
        str += names[i] + " ";
    }
    alert(str);
}

function Task_6()
{
    function vol(a,b,h)
    {
        return a * b * h;
    }
    
    function volume(name) 
    {
        return function(a) 
        {
            return function(b)  
            {
                return function(h) 
                {
                    return name(a,b,h);
                } 
               
            }
        }
    }
    let vol1 = volume(vol);
    alert(vol1(10)(10)(10));
}

function Task_7()
{
    object = 
    {
        X : 0,
        Y : 0
    }
    for(let i  = 0; i < 10; i++)
    {
        alert("координаты: " +object.X + " " + object.Y)
        let choice = prompt("введите направление","");
        switch(choice)
        {
            case "left":
                {
                    object.X -=10;
                    break;
                }
            case "right":
                {
                        object.X +=10;
                        break;
                }   
            case "down":
                {
                    object.Y -=10;
                    break;
                } 
            case "up":
                {
                        object.Y +=10;
                        break;
                }
        }
    }
    alert("координаты: " +object.X + " " + object.Y)
}
