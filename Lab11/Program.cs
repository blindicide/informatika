using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Linq;

abstract class TransportCompany {
    public string Name;
    public int Price, Cars, Tonnage;
    private int Department;
    abstract public void ChangeValue(int a);
    abstract public int ChangePrivateValue{
        get;
        set;
    }
}
class Automobile : TransportCompany {
    //private int Price;
    private int Department;

    // public string Name;
    public Automobile(string Name, int newPrice, int newDepartment){
        this.Name = Name;
        this.Price = newPrice;
        this.Department = newDepartment;
    }
    public override void ChangeValue (int newPrice){
        this.Price = newPrice;
    }

    public override int ChangePrivateValue{
        get { return Department; }
        set { if (Department != value){ Department = value; }}
    }
}

class Train : TransportCompany {
    private int Department;

    public Train(string Name, int newCars, int newDepartment){
        this.Name = Name;
        this.Cars = newCars;
        this.Department = newDepartment;
    }

    public override void ChangeValue (int newCars){
        this.Cars = newCars;
    }

    public override int ChangePrivateValue{
        get { return Department; }
        set { if (Department != value){ Department = value; }}
    }

}

class Ship : TransportCompany {
    private int Department;

    public Ship(string Name, int newTonnage, int newDepartment){
        this.Name = Name;
        this.Tonnage = newTonnage;
        this.Department = newDepartment;
    }

    public override void ChangeValue (int newTonnage){
        this.Tonnage = newTonnage;
    }

    public override int ChangePrivateValue{
        get { return Department; }
        set { if (Department != value){ Department = value; }}
    }
}

class VesselRegistry {

    public TransportCompany[] Collection = new TransportCompany[0];

    public void Main(){
        Console.WriteLine("Возможные действия (введите номер):");
        Console.WriteLine("1 - Добавить новый объект");
        Console.WriteLine("2 - Удалить объект");
    }

    public void AddNewElement(TransportCompany tmpElement){
        Array.Resize(ref Collection, Collection.Length + 1);
        Collection[Collection.Length - 1] = tmpElement;
    }
    public void DeleteElement(int index){
        index = index - 1;
        int arrlen = Collection.Length;
        TransportCompany[] tmpCol = new TransportCompany[0];
        for (int i = 0; i < arrlen; i++){
            if (i != index){
                Array.Resize(ref tmpCol, tmpCol.Length + 1);
                tmpCol[tmpCol.Length - 1] = Collection[i];
            }
        }
        Collection = tmpCol;
    }
    public void ChangeElValue(int tip, int newValue, int index){
        index = index - 1;
        TransportCompany objectUsed = Collection[index];
        if (tip == 0){
            objectUsed.ChangeValue(newValue);
        }
        else{
            objectUsed.ChangePrivateValue = newValue;
        }
    }
    public void GetAllElements(){
        if (Collection.Length < 1){
            Console.WriteLine("Коллекция пуста. Добавьте туда что-нибудь.");
        }
        else{
            int arrlen = Collection.Length;
            for (int i = 0; i < arrlen; i++){
                TransportCompany currentElement = Collection[i];
                Type elType = currentElement.GetType();
                string elementType = elType.ToString();
                int Department = currentElement.ChangePrivateValue;
                if (elementType == "Automobile"){
                    Console.Write("Индекс ");
                    Console.Write(i);
                    Console.Write(": ");
                    Console.Write(currentElement.Name);
                    Console.Write(" - автомобиль. Его стоимость - ");
                    Console.Write(currentElement.Price);
                    Console.Write(" рублей. Он относится к подразделению номер ");
                    Console.WriteLine(Department);
                }
                if (elementType == "Train"){
                    Console.Write("Индекс ");
                    Console.Write(i);
                    Console.Write(": ");
                    Console.Write(currentElement.Name);
                    Console.Write(" - поезд. В нём ");
                    Console.Write(currentElement.Cars);
                    Console.Write(" вагонов. Он относится к подразделению номер ");
                    Console.WriteLine(Department);
                }
                if (elementType == "Ship"){
                    Console.Write("Индекс ");
                    Console.Write(i);
                    Console.Write(": ");
                    Console.Write(currentElement.Name);
                    Console.Write(" - корабль. Его водоизмещение - ");
                    Console.Write(currentElement.Tonnage);
                    Console.Write(" тонн. Он относится к подразделению номер ");
                    Console.Write(Department);
                    Console.WriteLine(".");
                }
            }
        }
    }

}

class HelloWorld2{
    static void Main(){
        Automobile Honda = new Automobile("Honda 3455", 4000000, 5);
        VesselRegistry GeneralRegistry = new VesselRegistry();
        GeneralRegistry.AddNewElement(Honda);
        Ship HMM1 = new Ship("NS Vigilant", 5400, 54);
        GeneralRegistry.AddNewElement(HMM1);
        GeneralRegistry.GetAllElements();
    }
}