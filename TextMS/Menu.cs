using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMS
{
    class Menu
    {
        public Menu()
        {
            TextConnection connection = new TextConnection(
                @"C:\Users\Home\Desktop\c sharp\Task03\Task03\textbase.txt");         //path to file
            int choice = 0;
            while (choice != 5)
            {
                Print();
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Clear();
                    Console.WriteLine("     What information you want to add?");
                    int desicion = 0;
                    while (desicion != 3)
                    {
                        print_desicion();
                        desicion = Convert.ToInt32(Console.ReadLine());
                        if (desicion == 1)                             //add new information about University
                        {
                            Console.Clear();
                            Console.WriteLine("You choose University");
                            Console.WriteLine("Enter University name : ");
                            string univ_name = Console.ReadLine();
                            Console.WriteLine("Enter rating : ");
                            string rating = Console.ReadLine();
                            Console.WriteLine("Enter the city of the University : ");
                            string city = Console.ReadLine();

                            Table table1 = connection.GetTable("University");

                            string[] new_info1 = new string[] { univ_name, rating, city };
                            table1.Create(new_info1);
                            table1.ExecuteChanges();
                        }
                        else if (desicion == 2)                            //add new information about Subject
                        {
                            Console.Clear();
                            Console.WriteLine("You choose Subject");
                            Console.WriteLine("Enter the Subject : ");
                            string subj_name = Console.ReadLine();
                            Console.WriteLine("Enter how semesters this Subject lasts: ");
                            string semester = Console.ReadLine();

                            Table table = connection.GetTable("Subject");

                            string[] new_info = new string[] { subj_name, semester };
                            table.Create(new_info);
                            table.ExecuteChanges();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You enter wrong number!");
                        }
                    }
                }              //add

                else if (choice == 2)
                {
                    Console.Clear();
                    Console.WriteLine("     What information you want to edit?");
                    int desicion = 0;
                    while (desicion != 3)
                    {
                        print_desicion();
                        desicion = Convert.ToInt32(Console.ReadLine());
                        if (desicion == 1)                                   //edit information about  University
                        {
                            Console.Clear();
                            Console.WriteLine("    You choose University");
                            Console.WriteLine("Enter the name of the University: ");
                            string old_name = Console.ReadLine();
                            Console.WriteLine("Enter new rating:");
                            string rating = Console.ReadLine();
                            Console.WriteLine("Enter new city of the University: ");
                            string city = Console.ReadLine();

                            Table table1 = connection.GetTable("University");

                            string[] new_info1 = new string[] { old_name, rating, city };
                            table1.Update("name", old_name, new_info1);
                            table1.ExecuteChanges();
                        }
                        else if (desicion == 2)                        //edit information about Subject
                        {
                            Console.Clear();
                            Console.WriteLine("    You choose Subject");
                            Console.WriteLine("Enter Subject name : ");
                            string old_name = Console.ReadLine();
                            Console.WriteLine("Enter how semesters this Subject lasts: ");
                            string semester = Console.ReadLine();

                            Table table2 = connection.GetTable("Subject");

                            string[] new_info2 = new string[] { old_name, semester };
                            table2.Update("subj_name", old_name, new_info2);
                            table2.ExecuteChanges();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You enter wrong number!");
                        }
                    }
                }         //edit

                else if (choice == 3)
                {
                    Console.Clear();
                    Console.WriteLine("     What information you want to delete?");
                    int desicion = 0;
                    while (desicion != 3)
                    {
                        print_desicion();
                        desicion = Convert.ToInt32(Console.ReadLine());
                        if (desicion == 1)                      //delete information from University
                        {
                            Console.Clear();
                            Console.Write("Enter name of University what you want to delete : ");
                            string name = Console.ReadLine();

                            Table table1 = connection.GetTable("University");
                            table1.Delete("name", name);
                            table1.ExecuteChanges();
                        }
                        else if (desicion == 2)               //delete information from Subject
                        {
                            Console.Clear();
                            Console.Write("Enter the Subject what you want to delete : ");
                            string name = Console.ReadLine();

                            Table table2 = connection.GetTable("Subject");
                            table2.Delete("subj_name", name);
                            table2.ExecuteChanges();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You enter wrong number!");
                        }
                    }
                }        //delete

                else if (choice == 4)
                {
                    Console.Clear();
                    Console.WriteLine("     What information do you want to see?");
                    int desicion = 0;
                    while (desicion != 3)
                    {
                        print_desicion();
                        desicion = Convert.ToInt32(Console.ReadLine());
                        if (desicion == 1)
                        {
                            Console.Clear();
                            Table table1 = connection.GetTable("University");
                            Console.WriteLine(table1.GetContent());
                            table1.ExecuteChanges();
                        }
                        else if (desicion == 2)
                        {
                            Console.Clear();
                            Table table2 = connection.GetTable("Subject");
                            //Console.WriteLine(table2.ToString());
                            Console.WriteLine(table2.GetContent());
                            table2.ExecuteChanges();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You enter wrong number!");
                        }
                    }
                }         //see

                else if (choice == 5)
                {
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Print();
                    choice = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        public void print_desicion()
        {
            Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine("::Enter 1 to work with University       ::");
            Console.WriteLine("::Enter 2 to work with Subject          ::");
            Console.WriteLine("::Enter 3 to return to Main Menu        ::");
            Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::");
        }

        public void Print()
        {
            Console.Clear();
            Console.WriteLine("+++++++++++++++++MAIN MENU+++++++++++++++++++++++++++++");
            Console.WriteLine("++Enter 1 if you want to add new information         ++");
            Console.WriteLine("++Enter 2 if you want to edit some information       ++");
            Console.WriteLine("++Enter 3 if you want to delete some information     ++");
            Console.WriteLine("++Enter 4 if you want to see information             ++");
            Console.WriteLine("++                                                   ++");
            Console.WriteLine("++Enter 5 if you want to exit                        ++");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }
    }
}
