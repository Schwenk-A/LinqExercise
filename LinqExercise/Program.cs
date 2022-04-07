using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sum = numbers.Sum();
            Console.WriteLine(sum);
            var average = numbers.Average();
            Console.WriteLine(average);
            //Order numbers in ascending order and decsending order. Print each to console.
            var ascending = numbers.OrderBy(x=>x);             
            Console.WriteLine(ascending);
            var decsending = numbers.OrderByDescending(x => x);
            Console.WriteLine(decsending);


            //Print to the console only the numbers greater than 6

            var greaterThanSix = numbers.Where(x => x > 6);
            Console.WriteLine(greaterThanSix);

            Console.Clear();

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var topFour = ascending.Take(4).ToList();
            topFour.ForEach(Console.WriteLine);

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers.Select((x, i) => i == 4 ? 28 : x).OrderByDescending(x=>x).ToList().ForEach(Console.WriteLine);
            
            
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var firstName = from emp in employees
                            where emp.FirstName[0] == 'C' || emp.FirstName[0] == 'S'
                            orderby emp.FirstName ascending
                            select emp.FirstName;
            foreach (var i in firstName)
            {
                Console.WriteLine(i);
            }




            var fullNameAgeTwentySixYearsOldAndOlder = from info in employees
                                               where info.Age>26 
                                               orderby info.Age ascending
                                               orderby info.FirstName
                                               select info;
            foreach (var employee in fullNameAgeTwentySixYearsOldAndOlder)
            {
                Console.WriteLine($"{ employee.Age} ,{ employee.FirstName} ");
            }

            //Print all the employees' FullName and Age
            //who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.



            //Print the Sum and then the Average of the employees' YearsOfExperience
            Console.WriteLine(employees.Sum(x => x.YearsOfExperience));
            Console.WriteLine(employees.Average(x => x.YearsOfExperience));

            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var yOE = from emp in employees
                      where emp.YearsOfExperience <= 10 &&
                      emp.Age > 35
                      select emp;
            foreach (var employee in yOE)
            {
                Console.WriteLine(employee.FullName);
            }

            //Add an employee to the end of the list without using employees.Add()

            employees.Append(new Employee());




            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
   //List<string> name = new List<string>