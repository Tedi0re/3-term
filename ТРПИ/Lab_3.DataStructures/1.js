function Task_1()
{
    let userMessage = prompt('Введите сообщение');
    let lowerCaseUserMessage = userMessage.toLowerCase()
    let d = lowerCaseUserMessage
    .replace(new RegExp('кот', 'g'), '*')
    .replace(new RegExp('собак', 'g'), 'Собак')
    .replace(new RegExp('пес', 'g'), 'многоуважаемый пес');
    alert(d);  
}


function Task_2()
{
    
    let Days = { Day: ["Понедельник","Вторник","Среда","Четверг","Пятница","Суббота","Воскресенье"]};
    let flag = true;
    while(flag)
    {
        let Day = prompt("Введите день недели:","");
        Day-=1;
        if(Day >=0)
        {
            alert(Days.Day[Day]);

            for(let i = 0; i < 7; i+=2)
            {
                alert(`${i+1} - ${Days.Day[i]}`);
            }
            flag = false;
        }
        else
        {
            alert("Неправильный ввод");
        }

    }
}

function Task_3()
{
    let btn1= document.querySelector('.btn-1');//поиск первого элемента
    let link1 = document.querySelector('.link1');
    let link2 = document.querySelector('.link2');

    let buttonsStyles = 
    {
        color: 'yellow',
        width: '80px',
        height: '40px',
        backgroundColor: 'black'
    }
    let link1Styles =   
    {
        color: 'red',
        textDecoration: 'none'
    }
    let link2Styles =   
    {
        color: 'blue',
        textDecoration: 'line-through'
    }

    btn1.addEventListener('focus', function() 
    {
        this.style.width = buttonsStyles.width;
        this.style.color = buttonsStyles.color;
        this.style.backgroundColor = buttonsStyles.backgroundColor;
    });
    btn1.addEventListener('blur', function() //при снятии фокуса
    {
        this.style.width = '';
        this.style.color = '';
        this.style.backgroundColor = '';
    });
    link1.addEventListener('focus', function() {
        this.style.color = link1Styles.color;
        this.style.textDecoration = link1Styles.textDecoration;
    })

    link1.addEventListener('blur', function() {
        this.style.color = '';
        this.style.textDecoration = '';
    })

    link2.addEventListener('focus', function() {
        this.style.color = link2Styles.color;
        this.style.textDecoration = link2Styles.textDecoration;
    })

    link2.addEventListener('blur', function() {
        this.style.color = '';
        this.style.textDecoration = '';
    })
}

function Task_4()
{
    let set = new Set();
    let choice = "";
    while(true)
    {
        choice = prompt(`Выберите товар:`,"")
        if(choice == null) break;
        if(choice == "") alert("Вы не выбрали товар");
        else
        {
            if(set.has(choice))
            {
                set.delete(choice);
                alert(`Товар ${choice} удалён из списка`);
            }
            else
            {
                set.add(choice);
                
                alert(`товар ${choice} добавлен в список`);
            }
            let str = "";
            for(let item of set)//преобразование коллекции в одну строку
            {
                str += item + "\n";
            }
            alert(`Количество товаров: ${set.size}\nСписок товаров:\n${str}`)
        }
        
    }
}

function Task_5()
{
    let map = new Map();
    let choiceAction = "";
    let keys = [];
    while(true)
    {
        let element = 
        {
            nameElement: "",
            numberOfElement: 0,
        }
        choiceAction = prompt("добавить, удалить товар","");
        if(choiceAction == null) break;
        if(choiceAction == "") alert("Вы не выбрали действие");
        else
        {
            
            element.nameElement = prompt("Введите товар","");
            element.numberOfElement =parseInt(prompt("Введите количество товара",""));
            let id = "#"+ element.nameElement;
            if(element.nameElement == null || element.nameElement == "" || element.numberOfElement == null || element.numberOfElement == "") alert("Вы не выбрали товар");
            else
            {
                switch(choiceAction)
                {
                    case "добавить":
                    {
                        if(map.has(id))
                        {
                            let buf = map.get(id);
                            buf.numberOfElement+=element.numberOfElement;
                            map.delete(id);
                            map.set(id,buf);
                        }
                        else
                        {
                            keys.push(id);
                            map.set(id, element);  
                        }
                        alert("Товар добавлен");
                        break;
                    }
                    case "удалить":
                    {
                        if(map.has(id))
                        {
                            let buf = map.get(id);
                            if(buf.numberOfElement <= element.numberOfElement)
                            {
                                for (let i = 0; i < keys.length; i++)
                                {
                                    if(keys[i] == id) keys.splice(i,1);
                                }
                                map.delete(id);
                            }
                            else
                            {
                                buf.numberOfElement-=element.numberOfElement;
                                map.delete(id);
                                map.set(id,buf);
                                
                            }
                            alert("Товар удален");
                        }
                        else
                        {
                            alert("Товар не найден");
                        }
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
        }

        let str = "";
        let sum = 0;
        for (let i = 0; i < keys.length; i++)//преобразование коллекции в одну строку
        {
            let buf = map.get(keys[i]);
            str += buf.nameElement + "\t"+ buf.numberOfElement + "\t" + keys[i] + "\n";
            sum+=buf.numberOfElement;
        }
        alert(`Количество товаров: ${map.size}\nСумма товаров: ${sum}\nСписок товаров:\n${str}`)
    }
}


