using System;
using System.Collections.Generic;

namespace PersonManagement
{
    internal class Program
    {
        public static List<Person> persons { get; set; } = new List<Person>();
        static void Main(string[] args)
        {

            Console.WriteLine("Our available commands :");
            Console.WriteLine("/add-new-person");
            Console.WriteLine("/remove-person by fin");
            Console.WriteLine("/remove-all-persons");
            Console.WriteLine("/remove-by-Id");
            Console.WriteLine("/show-persons");
            Console.WriteLine("/exit");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter command : ");
                string command = Console.ReadLine();

                if (command == "/add-new-person")
                {
                    Console.Write("Please add person's name :");
                    string name = Console.ReadLine();

                    Console.Write("Please add person's surname :");
                    string lastName = Console.ReadLine();

                    Console.Write("Please add person's FIN code :");
                    string fin = Console.ReadLine();

                    Person person = AddNewPerson(name, lastName, fin);

                    Console.WriteLine(person.GetInfo() + " - Added to system.");

                }
                else if (command == "/remove-person by fin")
                {
                    Console.Write("To remove person, please enter his/her FIN code : ");
                    string fin = Console.ReadLine();
                    for (int i = 0; i < persons.Count; i++)
                    {
                        if (persons[i].FIN == fin)
                        {
                            Console.WriteLine(persons[i].GetInfo());
                            persons.RemoveAt(i);
                            Console.WriteLine("Person removed successfully");
                        }
                    }

                }
                else if (command == "/remove-all-persons")
                {
                    for (int i = persons.Count - 1; i >= 0; i--)
                    {
                        persons.RemoveAt(i);
                    }
                    Console.WriteLine("Persons removed successfully");
                }
                else if(command == "/remove-by-Id")
                {
                    Console.WriteLine("To remove id, please enter id number : ");
                    uint id=Convert.ToUInt32( Console.ReadLine());
                    RemoveById(id);

                }
                else if (command == "/show-persons")
                {
                    Console.WriteLine("Persons in database : ");
                    foreach (Person person in persons)
                    {
                        Console.WriteLine(person.GetInfo());
                    }
                }
                else if (command == "/exit")
                {
                    Console.WriteLine("Thanks for using our application!");
                    break;
                }
                else
                {
                    Console.WriteLine("Command not found, please enter command from list!");
                    Console.WriteLine();
                }
            }
        }
        public static Person AddNewPerson(string name, string lastName, string fin)
        {
            Person person = new Person(name, lastName, fin);
            persons.Add(person);
            return person;
        }
        public static uint RemoveById(uint id)
        {
            for(int i = 0; i < persons.Count; i++)
            {
                if(persons[i].Id == id)
                {
                    Console.WriteLine(persons[i].GetInfo());
                    persons.RemoveAt(i);
                    Console.WriteLine("Id removed successfully");
                }
            }
            return id;
        }


    }

    class Person
    {
        private static uint currentIdCount = 1;
        public uint Id { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string _fin;
        public string FIN
        {
            get
            {
                return _fin;
            }
            set
            {
                if (value.Length == 7)
                {
                    _fin = value;
                }
                else
                {
                    Console.WriteLine("Fin must be 7 characters");
                }

            }
        }

        public Person(string name, string lastName, string fin)
        {
            Name = name;
            LastName = lastName;
            FIN = fin;
            Id = currentIdCount++;
        }

        public string GetFullName()
        {
            return Name + " " + LastName;
        }

        public string GetInfo()
        {
            return Id + " " + Name + " " + LastName + " " + FIN;
        }


    }
}
