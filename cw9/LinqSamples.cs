using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqConsoleApp
{
    public class LinqSamples
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        public LinqSamples()
        {
            LoadData();
        }

        public void LoadData()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();

            #region Load depts
            var d1 = new Dept
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            var d2 = new Dept
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            var d3 = new Dept
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;
            #endregion

            #region Load emps
            var e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            var e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            var e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            var e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            var e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            var e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            var e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            Emps = empsCol;

            #endregion

        }


        /*
            Celem ćwiczenia jest uzupełnienie poniższych metod.
         *  Każda metoda powinna zawierać kod C#, który z pomocą LINQ'a będzie realizować
         *  zapytania opisane za pomocą SQL'a.
         *  Rezultat zapytania powinien zostać wyświetlony za pomocą kontrolki DataGrid.
         *  W tym celu końcowy wynik należy rzutować do Listy (metoda ToList()).
         *  Jeśli dane zapytanie zwraca pojedynczy wynik możemy je wyświetlić w kontrolce
         *  TextBox WynikTextBox.
        */

        /// <summary>
        /// SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        public void Przyklad1()
        {
            //var res = new List<Emp>();
            //foreach(var emp in Emps)
            //{
            //    if (emp.Job == "Backend programmer") res.Add(emp);
            //}

            //1. Query syntax (SQL)
            var res = from emp in Emps
                      where emp.Job == "Backend programmer"
                      select new
                      {
                          Nazwisko = emp.Ename,
                          Zawod = emp.Job
                      };


            //2. Lambda and Extension methods
            // ResultDataGridView.DataSource =
            // res.ToList().ToString()
            for(int i = 0; i <  res.Count(); i++)
               Console.WriteLine( "Nazwisko " + res.ElementAt(i).Nazwisko  + " Job " + res.ElementAt(i).Zawod );
        }

        /// <summary>
        /// SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        public void Przyklad2()
        {
            var res = Emps.Where((emp) => emp.Job == "Frontend programmer" && emp.Salary > 1000)
                          .OrderByDescending(emp => emp.Ename);
            Console.WriteLine("Przyklad 2");
            ShowResEmp(res);
        }

        private void ShowResEmp(IEnumerable<Emp> res) {
            for (int i = 0; i < res.Count(); i++) 
            {
                Console.WriteLine(res.ElementAt(i).ToString());
            }
        }

        /// <summary>
        /// SELECT MAX(Salary) FROM Emps;
        /// </summary>
        public void Przyklad3()
        {
            var res = Emps.Max(emp => emp.Salary);
            Console.WriteLine("Przyklad 3");
            Console.WriteLine(res);
        }

        /// <summary>
        /// SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        public void Przyklad4()
        {
            Console.WriteLine("Przyklad 4");
            var res = Emps.Where(emp => emp.Salary == (Emps.Max(emp => emp.Salary)));
             ShowResEmp(res);
        }

        /// <summary>
        /// SELECT ename AS Nazwisko, job AS Praca FROM Emps;
        /// </summary>
        public void Przyklad5()
        {
            Console.WriteLine("Przyklad 5");
            var res = Emps.Select(emp => new {
                                    Nazwisko = emp.Ename,
                                    Praca = emp.Salary
                                  }
            );

            for (int i = 0; i < res.Count(); i++) {
                Console.WriteLine("Nazwisko " + res.ElementAt(i).Nazwisko + " Praca " + res.ElementAt(i).Praca);
            }
        }

        /// <summary>
        /// SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        /// INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        /// Rezultat: Złączenie kolekcji Emps i Depts.
        /// </summary>
        public void Przyklad6()
        {
            Console.WriteLine("Przyklad 6");
            var res = from emp in Emps
                      join dept in Depts on emp.Deptno equals dept.Deptno
                      select new { 
                        emp.Ename,
                        emp.Job,
                        dept.Dname
                      };

            /*
var res = Emps.InnerJoin
   .Select(emp => new
{

}
)
*/
            foreach (var result  in res) 
            {
                Console.WriteLine("Ename " + result.Ename + ", Job " + result.Job + ", Dname " + result.Dname );
            } 
        }

        /// <summary>
        /// SELECT Job AS Praca, COUNT(1) LiczbaPracownikow FROM Emps GROUP BY Job;
        /// </summary>
        public void Przyklad7()
        {
            Console.WriteLine("Przyklad 7");

            var res = from emp in Emps
                      group new { Praca = emp.Job } by emp.Job
                      ; // , Emps.Count()
            /* select new
                      {
                          Praca = emp.Job,
                          Emps.Count()
                       };
            */
            /*
            var res = Emps.GroupBy(emp => emp.Job)
                          .Count(emp => 1 == 1)
                          .Select(emp => { return emp.Job; );// .Count();
            */
            for (int i = 0; i < res.Count(); i++)
            {
                Console.WriteLine("Praca " + res.ElementAt(i).Key + ", Count " + res.ElementAt(i).Count(emp => 1 == 1));
            }

        }

        /// <summary>
        /// Zwróć wartość "true" jeśli choć jeden
        /// z elementów kolekcji pracuje jako "Backend programmer".
        /// </summary>
        public void Przyklad8()
        {
            Console.WriteLine("Przyklad 8");
            var res = Emps.Where(emp => emp.Job == "Backend programmer");
            // .Select(emp => true );
            if (res.Count() > 0) Console.WriteLine("true");
            else Console.WriteLine("false");
        }

        /// <summary>
        /// SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        /// ORDER BY HireDate DESC;
        /// </summary>
        public void Przyklad9()
        {
            Console.WriteLine("Przyklad 9");
            var res = Emps.Where(emp => emp.Job == "Frontend programmer")
                          .OrderByDescending(emp => emp.HireDate)
                          .FirstOrDefault();
            Console.WriteLine("Emp " + res);
        }

        /// <summary>
        /// SELECT Ename, Job, Hiredate FROM Emps
        /// UNION
        /// SELECT "Brak wartości", null, null;
        /// </summary>
        public void Przyklad10Button_Click()
        {
            var employee = new Emp();
            var eee = Emps.Select(emp => { return new { Ename = "Brak wartości", employee.Job, employee.HireDate }; }); 
            Console.WriteLine("Przyklad 10");
            var res = Emps.Select(emp => { return new { emp.Ename, emp.Job, emp.HireDate }; })
                          .Union( eee ) ;
            for (int i = 0; i < res.Count(); i++)
                Console.WriteLine(res.ElementAt(i));
        }

        //Znajdź pracownika z najwyższą pensją wykorzystując metodę Aggregate()
        public void Przyklad11()
        {
            Console.WriteLine("Przyklad 11");
            
        }

        //Z pomocą języka LINQ i metody SelectMany wykonaj złączenie
        //typu CROSS JOIN
        public void Przyklad12()
        {
            
        }
    }
}
