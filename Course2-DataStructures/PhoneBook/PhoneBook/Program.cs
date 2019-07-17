using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            PhoneBookManager pbm = new PhoneBookManager();


            int numberOfQueries = Convert.ToInt32(Console.ReadLine());
            List<string> queries = new List<string>();

            for (int i = 0; i < numberOfQueries; i++)
            {
                string tempQuery = Console.ReadLine();
                queries.Add(tempQuery);
            }

            for (int i = 0; i < queries.Count; i++)
            {

                string[] query = queries[i].Split(' ');

                string action = query[0];

                if(action == "add")
                {
                    string number = query[1];
                    string name = query[2];

                    pbm.AddEntry(name, number);

                }
                else if( action == "find")
                {
                    string number = query[1];

                    string nameVal = pbm.FindNumber(number);

                    Console.WriteLine(nameVal);
                }
                else if(action == "del")
                {
                    string number = query[1];
                    pbm.DeleteEntry(number);
                }
            }
        }
    }

    public class PhoneBookManager
    {
        private Dictionary<string, string> phoneToNameMap;


        private bool IsNameValid(string name)
        {
            return name.Length > 0 && name.Length <= 15;
        }

        private bool IsNumberValid(string number)
        {
            return number.Length > 0 && number.Length <=7;
        }

        public PhoneBookManager()
        {
            this.phoneToNameMap = new Dictionary<string, string>();
        }

        public void AddEntry(string name, string number)
        {
            if(!IsNameValid(name) || !IsNumberValid(number))
            {
                // return;
            }

            if (!this.phoneToNameMap.ContainsKey(number))
            {
                this.phoneToNameMap.Add(number, name);
            }
            else
            {
                this.phoneToNameMap[number] = name;    
            }
        }

        public void DeleteEntry(string number)
        {
            
            if (this.phoneToNameMap.ContainsKey(number))
            {
                this.phoneToNameMap.Remove(number);
            }
        }

        public string FindNumber(string number)
        {
            if(this.phoneToNameMap.ContainsKey(number))
            {
                return this.phoneToNameMap[number];
            }
            else
            {
                return "not found";
            }
        }
    }
}
