using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Linq;

abstract class Vessel {
    public string Name;
    public int Price, Cars, Tonnage;
    private int Unit;
    abstract public void ChangeValue(int a);
    
    abstract public void ChangeName(string a);
    abstract public int ChangePrivateValue{
        get;
        set;
    }
}
class Automobile : Vessel {
    //private int Price;
    private int Unit;

    // public string Name;
    public Automobile(string Name, int newPrice, int newDepartment){
        this.Name = Name;
        this.Price = newPrice;
        this.Unit = newDepartment;
    }
    public override void ChangeValue (int newPrice){
        this.Price = newPrice;
    }
    public override void ChangeName (string newName){
        this.Name = newName;
    }

    public override int ChangePrivateValue{
        get { return Unit; }
        set { if (Unit != value){ Unit = value; }}
    }
}

class Train : Vessel {
    private int Unit;

    public Train(string Name, int newCars, int newDepartment){
        this.Name = Name;
        this.Cars = newCars;
        this.Unit = newDepartment;
    }

    public override void ChangeValue (int newCars){
        this.Cars = newCars;
    }
    public override void ChangeName (string newName){
        this.Name = newName;
    }

    public override int ChangePrivateValue{
        get { return Unit; }
        set { if (Unit != value){ Unit = value; }}
    }

}

class Ship : Vessel {
    private int Unit;

    public Ship(string Name, int newTonnage, int newDepartment){
        this.Name = Name;
        this.Tonnage = newTonnage;
        this.Unit = newDepartment;
    }

    public override void ChangeValue (int newTonnage){
        this.Tonnage = newTonnage;
    }
    public override void ChangeName (string newName){
        this.Name = newName;
    }

    public override int ChangePrivateValue{
        get { return Unit; }
        set { if (Unit != value){ Unit = value; }}
    }
}

class VesselRegistry {

    public Vessel[] Collection = new Vessel[0];

    public void AddNewElement(Vessel tmpElement){
        Array.Resize(ref Collection, Collection.Length + 1);
        Collection[Collection.Length - 1] = tmpElement;
    }
    public void Menu(){
        Console.WriteLine("");
        Console.WriteLine("Добро пожаловать в базу данных корпорации 'Аллисон Транспорт', сотрудник.");
        Console.WriteLine("Возможные действия:");
        Console.WriteLine("1 - Создать запись о т/с");
        Console.WriteLine("2 - Удалить запись о т/с");
        Console.WriteLine("3 - Вывести сведения о т/с в реестре");
        Console.WriteLine("4 - Изменить данные т/с");
        Console.WriteLine("5 - Выйти из программы");
        int inp;
        Console.Write("Напишите необходимое действие: ");
        inp = Convert.ToInt32(Console.ReadLine());
        if (inp == 1){
            string nme;
            int unit, pub;
            Console.Write("Введите название т/с: ");
            nme = Console.ReadLine();
            Console.Write("Введите стоимость (для машины), к-во вагонов (для поезда) или тоннаж (для корабля): ");
            pub = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите номер подразделения, к которому относится т/с: ");
            unit = Convert.ToInt32(Console.ReadLine());
            int tp;
            Console.Write("Напишите тип т/с (1 - для машины, 2 - для поезда, 3 - для корабля): ");
            tp = Convert.ToInt32(Console.ReadLine());
            if (tp == 1){
                Vessel NewObj = new Automobile(nme, pub, unit);
                AddNewElement(NewObj);
                Console.WriteLine("Добавлена новая машина.");
            }
            if (tp == 2){
                Vessel NewObj = new Train(nme, pub, unit);
                AddNewElement(NewObj);
                Console.WriteLine("Добавлен новый поезд.");
            }
            if (tp == 3){
                Vessel NewObj = new Ship(nme, pub, unit);
                AddNewElement(NewObj);
                Console.WriteLine("Добавлен новый корабль.");
            }
            else{
                Console.WriteLine("Ошибка.");
            }
        }
        if (inp == 2){
            Console.Write("Введите индекс т/с: ");
            int sps = Convert.ToInt32(Console.ReadLine());
            DeleteElement(sps);
            Console.WriteLine("т/с удалён.");
        }
        if (inp == 3){
            GetAllElements();
        }
        if (inp == 4){
            int tip, index;
            string val, val1;
            Console.Write("Введите индекс т/с: ");
            index = Convert.ToInt32(Console.ReadLine());
            Console.Write("Если нужно изменить открытые данные - введите 0, если департамент - 1, если название - 2");
            tip = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите новое значение или название: ");
            val = Console.ReadLine();
            ChangeElValue(index, tip, val);
        }
        if (inp == 5){
            Console.WriteLine("Закрытие программы...");
            Environment.Exit(0);
        }
    }
    public void DeleteElement(int index){
        index = index - 1;
        int arrlen = Collection.Length;
        Vessel[] tmpCol = new Vessel[0];
        for (int i = 0; i < arrlen; i++){
            if (i != index){
                Array.Resize(ref tmpCol, tmpCol.Length + 1);
                tmpCol[tmpCol.Length - 1] = Collection[i];
            }
        }
        Collection = tmpCol;
    }
    public void ChangeElValue(int index, int tip, string newValue) {
        index = index - 1;
        int ev;
        Vessel objectUsed = Collection[index];
        if (tip == 0){
            ev = Convert.ToInt32(newValue);
            objectUsed.ChangeValue(ev);
        }
        if (tip == 2){
            objectUsed.ChangeName(newValue);
        }
        else{
            ev = Convert.ToInt32(newValue);
            objectUsed.ChangePrivateValue = ev;
        }
    }
    public void GetAllElements(){
        if (Collection.Length < 1){
            Console.WriteLine("Коллекция пуста. Добавьте туда что-нибудь.");
        }
        else{
            int arrlen = Collection.Length;
            for (int i = 0; i < arrlen; i++){
                Vessel currentElement = Collection[i];
                Type elType = currentElement.GetType();
                string elementType = elType.ToString();
                int Unit = currentElement.ChangePrivateValue;
                if (elementType == "Automobile"){
                    Console.Write("Индекс ");
                    Console.Write(i);
                    Console.Write(": ");
                    Console.Write(currentElement.Name);
                    Console.Write(" - автомобиль. Его стоимость - ");
                    Console.Write(currentElement.Price);
                    Console.Write(" рублей. Он относится к подразделению номер ");
                    Console.Write(Unit);
                    Console.WriteLine(".");
                }
                if (elementType == "Train"){
                    Console.Write("Индекс ");
                    Console.Write(i);
                    Console.Write(": ");
                    Console.Write(currentElement.Name);
                    Console.Write(" - поезд. В нём ");
                    Console.Write(currentElement.Cars);
                    Console.Write(" вагонов. Он относится к подразделению номер ");
                    Console.Write(Unit);
                    Console.WriteLine(".");
                }
                if (elementType == "Ship"){
                    Console.Write("Индекс ");
                    Console.Write(i);
                    Console.Write(": ");
                    Console.Write(currentElement.Name);
                    Console.Write(" - корабль. Его водоизмещение - ");
                    Console.Write(currentElement.Tonnage);
                    Console.Write(" тонн. Он относится к подразделению номер ");
                    Console.Write(Unit);
                    Console.WriteLine(".");
                }
            }
        }
    }

}

class HelloWorld2{
    static void Main(){
        VesselRegistry GeneralRegistry = new VesselRegistry();
        int ab = 3;
        while (ab == 3){
            GeneralRegistry.Menu();
        }
    }
}