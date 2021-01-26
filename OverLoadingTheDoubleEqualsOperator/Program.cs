using System;

namespace OverLoadingTheDoubleEqualsOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee();
            emp1.Id = 1;
            emp1.FirstName = "Bob";
            emp1.LastName = "Jones";

            Employee emp2 = new Employee();
            emp2.Id = 1;
            emp2.FirstName = "bob";
            emp2.LastName = "jones";

            //emp1 = null;
            //emp2 = null;

            //if (emp1 == null)
            //{
            //    Console.WriteLine("emp1 is null");

            //}
            //else
            //{
            //    Console.WriteLine("emp1 is not null");
            //}

            if (emp1 == emp2)
            {
                Console.WriteLine("emp1 is equal to emp2");
            }
            else
            {
                Console.WriteLine("emp1 is not equal to emp2");
            }

            Console.ReadKey();
        }
    }
    public class Employee:IEquatable<Employee>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static bool operator ==(Employee emp1, Employee emp2)
        {
            if (emp1 is null && emp2 is null)
                return true;

            if ((emp1 is null && emp2 is not null)
                || (emp1 is not null && emp2 is null))
                return false;


            if (emp1.Id.Equals(emp2.Id)
                && emp1.FirstName.Equals(emp2.FirstName,StringComparison.OrdinalIgnoreCase)
                && emp1.LastName.Equals(emp2.LastName, StringComparison.OrdinalIgnoreCase)
                )
            {
                return true;
            }

            return false;
        }
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            if (emp1 is null && emp2 is null)
                return false;

            if ((emp1 is null && emp2 is not null)
                || (emp1 is not null && emp2 is null))
                return true;

            if (!emp1.Id.Equals(emp2.Id)
                || !emp1.FirstName.Equals(emp2.FirstName, StringComparison.OrdinalIgnoreCase)
                || !emp1.LastName.Equals(emp2.LastName, StringComparison.OrdinalIgnoreCase)
                )
            {
                return true;
            }
            return false;
        }

        public bool Equals(Employee other)
        {
            if (other is null)
                return false;

            return other.Id.Equals(this.Id)
                && other.FirstName.Equals(this.FirstName, StringComparison.OrdinalIgnoreCase)
                && other.LastName.Equals(this.LastName, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return this.Id;
        }


    }
}
