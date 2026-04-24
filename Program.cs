using System;
using System.Collections.Generic;

enum Department { HR, IT, Finance, Marketing }

abstract class Employee
{
    string name;
    int age;
    Department department;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("İsim boş olamaz");
                return;
            }
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 18)
            {
                Console.WriteLine("Yaş 18 den büyük olamaz");
                return;
            }
            age = value;
        }
    }

    public Department Department
    {
        get { return department; }
        set { department = value; }
    }

    public Employee(string name, int age, Department department)
    {
        this.Name = name;
        this.Age = age;
        this.Department = department;
    }
    public abstract void Work();

}

interface IReportable
{
    void GenerateReport();
}

interface ITrainbale
{
    void AttendTraining();
}

class Developer : Employee, IReportable
{
    public Developer(string name, int age, Department department) : base(name, age, department) {
    
    }

    public override void Work()
    {
        Console.WriteLine($"{Name} kod yazıyor ");
    }

    public void GenerateReport()
    {
        Console.WriteLine($"{Name}  rapor yazıyor");
    }
}

class Manager : Employee, IReportable, ITrainbale
{
    public Manager(string name, int age, Department department) : base (name, age, department) { 
    }

    public override void Work()
    {
        Console.WriteLine($"{Name} yöneticilik yapıyor");
    }

    public void GenerateReport()
    {
        Console.WriteLine($"{Name}  rapor yazıyor");
    }

    public void AttendTraining()
    {
        Console.WriteLine($"{Name} eğitim alıyor.");
    }
}

class Intern : Employee, ITrainbale
{
    public Intern(string name, int age, Department department) : base(name, age, department)
    {
    }
    public override void Work()
    {
        Console.WriteLine($"{Name} stajyerlik yapıyor");
    }

    public void AttendTraining()
    {
        Console.WriteLine($"{Name} eğitim alıyor.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Çalışan Yönetim Sistemi:");
        Console.WriteLine();
        List<Employee> staff = new List<Employee>();
        
        staff.Add(new Developer("Ahmet Yılmaz", 28, Department.IT));
        staff.Add(new Developer("Zeynep Kaya", 25, Department.IT));
        staff.Add(new Manager("Mehmet Demir", 35, Department.HR));
        staff.Add(new Manager("Ayşe Şahin", 40, Department.Finance));
        staff.Add(new Intern("Can Öztürk", 22, Department.Marketing));
        staff.Add(new Intern("Elif Arslan", 21, Department.IT));

        Console.WriteLine("Çalışan Listesi:");
        Console.WriteLine();
        foreach (Employee emp in staff)
        {
            Console.WriteLine($"İsim: {emp.Name}");
            Console.WriteLine($"Yaş: {emp.Age}");
            Console.WriteLine($"Departman: {emp.Department}");
            Console.WriteLine($"Pozisyon: {emp.GetType().Name}");
            Console.WriteLine();

        }
        
        Console.WriteLine("Çalışanların Görevleri:");
        foreach (Employee emp in staff)
        {
            emp.Work();
        }
        Console.WriteLine();

        Console.WriteLine("Rapor Hazırlayanlar:");
        foreach (Employee emp in staff)
        {
            if (emp is IReportable reportable)
            {
                reportable.GenerateReport();
            }
        }
        Console.WriteLine();

        Console.WriteLine("Eğitim Alanlar:");
        foreach(Employee emp in staff)
        {
            if (emp is IReportable reportable)
            {
                reportable.GenerateReport();
            }

        }
        Console.WriteLine();

        Console.WriteLine("Hata Testleri:");
        {
            Developer yeniCalisan = new Developer("Ali Yücel", 16, Department.IT);
            Manager bos = new Manager("", 30, Department.HR);

        }


    }
}