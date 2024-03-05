
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
    public string Department { get; set; }
    public static List<Employee> GetAllEmployees()
    {
        List<Employee> listEmployees = new List<Employee>()
            {
                new Employee{ID= 101,Name = "Pooja", Salary = 10000, Department = "IT"},
                new Employee{ID= 102,Name = "Priyanka", Salary = 15000, Department = "Sales"},
                new Employee{ID= 103,Name = "Manoj", Salary = 25000, Department = "Sales"},
                new Employee{ID= 104,Name = "Santosh", Salary = 20000, Department = "IT"},
                new Employee{ID= 105,Name = "Vishal", Salary = 30000, Department = "IT"},
                new Employee{ID= 106,Name = "Sandhya", Salary = 25000, Department = "IT"},
                new Employee{ID= 107,Name = "Mahesh", Salary = 35000, Department = "IT"},
                new Employee{ID= 108,Name = "Manoj", Salary = 11000, Department = "Sales"},
                new Employee{ID= 109,Name = "Pradeep", Salary = 20000, Department = "Sales"},
                new Employee{ID= 110,Name = "Saurav", Salary = 25000, Department = "Sales"}
            };
        return listEmployees;
    }
}

class Linq
{
    static void Main(string[] args)
    {
        var result = from emp in Employee.GetAllEmployees() where (emp.Department == "IT" && emp.Salary > 20000 && emp.Name.StartsWith("M")) select emp;
        var r = Employee.GetAllEmployees().OrderBy(x => x.Department).ThenBy(x => x.Name);
        // var r1 = from emp1 in Employee.GetAllEmployees() orderby emp1.Department, emp1.Name select emp1;
        var r2 = (from i in Employee.GetAllEmployees() select i.Salary).SkipWhile(x => x < 30000);
        Console.WriteLine(r);
        foreach (var i in r)
        {
            Console.WriteLine(i.ID + " " + i.Name + " " + i.Salary + " " + i.Department);
            Console.WriteLine(i);

        }
        List<int> a = new List<int>() { 2, 3, 2, 5, 5, 6, 4, 3 };
        List<int> b = new List<int>() { 2, 3, 1, 2, 45 };
        var k = (from val in a select val).SkipWhile(x => x < 4).ToList();
        var res = (from num in a select num).Union(b);
        var res1 = Enumerable.Repeat("Dileep", 5);
        List<Object> ar = new List<Object>() { "dileep", 1, 2.4, '4', 1.2f, "kumar" };
        var rep = ar.OfType<string>();
        Console.WriteLine(rep);
        var unq = (from list in a
                       // orderby list
                   select list).ElementAt(3); ;
        foreach (var item in rep) Console.WriteLine(item);
        Console.WriteLine(unq);

    }
}




class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Employee1
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
}
class Program2
{
    static void Main(string[] args)
    {
        List<Department> departments = new List<Department>()
        {
            new Department { Id = 1, Name = "HR" },
            new Department { Id = 2, Name = "Engineering" },
            new Department { Id = 3, Name = "Finance" }
        };

        List<Employee1> employees = new List<Employee1>()
        {
            new Employee1 { Id = 1, Name = "John", DepartmentId = 1 },
            new Employee1{ Id = 2, Name = "Alice", DepartmentId = 2 },
            new Employee1 { Id = 3, Name = "Bob", DepartmentId = 2 },
            new Employee1 { Id = 4, Name = "Emma", DepartmentId = 3 },
            new Employee1 { Id = 5, Name = "Mark", DepartmentId = 1 }
        };
        var GroupJoin = from
                         dept in departments
                        join
                        emp in employees
                        on
                        dept.Id equals emp.Id into empGroup
                        select new
                        {
                            depart = dept.Id,
                            employ = empGroup.Select(e => e.Name)
                        };
        foreach (var item in GroupJoin)
        {
            Console.WriteLine($"Department: {item.depart}");
            foreach (var employee in item.employ)
            {
                Console.WriteLine($" - {employee}");
            }
        }
    }
}
class Program1
{
    static void Main(string[] args)
    {
        // Sample list of products
        List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200.50 },
            new Product { Id = 2, Name = "Smartphone", Category = "Electronics", Price = 699.99 },
            new Product { Id = 3, Name = "Headphones", Category = "Electronics", Price = 99.95 },
            new Product { Id = 4, Name = "T-Shirt", Category = "Clothing", Price = 25.50 },
            new Product { Id = 5, Name = "Jeans", Category = "Clothing", Price = 45.99 },
            new Product { Id = 6, Name = "Backpack", Category = "Accessories", Price = 49.99 }
        };

        // LINQ query to group products by category and calculate average price for each category
        var averagePricesByCategory = from product in products
                                      group product by product.Category into productGroup
                                      select new
                                      {
                                          Category = productGroup.Key,
                                          AveragePrice = productGroup.Average(p => p.Price)
                                      };


        Console.WriteLine("Average Prices by Category:");
        foreach (var result in averagePricesByCategory)
        {
            Console.WriteLine($"Category: {result.Category}, Average Price: {result.AveragePrice}");
        }
    }
}

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
}