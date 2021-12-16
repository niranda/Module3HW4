using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.Main
{
    public class Program
    {
        public event Func<double, double, double> Notify;

        public Func<double, double, double> SumHandler { get; set; }

        public double Sum(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public void TryCatchHandler(Action userMethod)
        {
            try
            {
                userMethod();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public double SumRes(double firstNum, double secondNum)
        {
            var listOfDelegates = Notify.GetInvocationList();
            double sum = 0;
            foreach (var i in listOfDelegates)
            {
                sum += (double)i.DynamicInvoke(firstNum, secondNum);
            }

            return sum;
        }

        public static void Main(string[] args)
        {
            var program = new Program();
            program.Notify += program.Sum;
            program.Notify += program.Sum;
            double sum = 0;

            program.TryCatchHandler(() =>
            {
                sum = program.SumRes(2, 3);
            });

            Console.WriteLine(sum);
            Console.WriteLine();

            var alinaContact = new Contact("Alina Zayceva", "09765675468", 28);
            var evgeniyContact = new Contact("Evegniy Burunov", "889644657", 23);
            var michaelContact = new Contact("Michael Zapravin", "837536539", 56);
            var anastasiaContact = new Contact("Anastasia Nirka", "2427282862", 24);
            var dariaContact = new Contact("Daria Zabornaya", "347532643", 18);
            var alexContact = new Contact("Alex Brown", "2639213237", 17);

            var listOfContacts = new List<Contact>();
            listOfContacts.AddRange(new Contact[6] { alinaContact, evgeniyContact, michaelContact, anastasiaContact, dariaContact, alexContact });

            var selectedContacts = listOfContacts.Where(w => w.FullName.ToUpper().StartsWith("A"));
            foreach (var i in selectedContacts)
            {
                Console.WriteLine(i.FullName);
            }

            Console.WriteLine();

            var doubledAge = listOfContacts.Select(s => s.Age * 2);

            foreach (var i in doubledAge)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            var firstContact = listOfContacts.FirstOrDefault();
            Console.WriteLine(firstContact.FullName);
            Console.WriteLine();

            var orderedContacts = listOfContacts.OrderBy(o => o.Phone.Length).ThenBy(t => t.Phone);
            foreach (var i in orderedContacts)
            {
                Console.WriteLine($"{i.FullName} {i.Phone}");
            }

            Console.WriteLine();

            var numOfContactsUnder20 = listOfContacts.Count(c => c.Age < 20);
            Console.WriteLine(numOfContactsUnder20);
        }
    }
}
