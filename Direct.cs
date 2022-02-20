using System;
using System.Collections.Generic;

namespace PhoneDirect
{
    public class Direct
    {
        private Dictionary<string, string> dict;

        public Direct()
        {
            dict = new Dictionary<string, string>();

            Add(new Person { FirstName = "test1", LastName = "test1", PhoneNumber = "0555 444 33 22" });
            Add(new Person { FirstName = "test2", LastName = "test2", PhoneNumber = "0555 666 77 88" });
            Add(new Person { FirstName = "test3", LastName = "test3", PhoneNumber = "0555 333 22 11" });
            Add(new Person { FirstName = "test4", LastName = "test4", PhoneNumber = "0555 777 88 99" });
            Add(new Person { FirstName = "test5", LastName = "test5", PhoneNumber = "0555 888 00 33" });
        }

        public void Add(Person person)
        {
            string key = person.FirstName + " " + person.LastName;
            dict.Add(key, person.PhoneNumber);
        }

        public bool Delete(Person person)
        {
            try
            {
                string key = person.FirstName + " " + person.LastName;
                dict.Remove(key);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Person person)
        {
            try
            {
                string key = person.FirstName + " " + person.LastName;
                dict[key] = person.PhoneNumber;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Dictionary<string, string> GetAll()
        {
            return dict;
        }

        public Dictionary<string, string> Get(Person person)
        {
            Dictionary<string, string> filteredDict = new Dictionary<string, string>();

            if (person.PhoneNumber is not null)
            {
                foreach (var item in dict)
                {
                    if (item.Value == person.PhoneNumber)
                    {
                        filteredDict.Add(item.Key, item.Value);
                    }
                }
            }
            else
            {
                string key = person.FirstName + " " + person.LastName;

                foreach (var item in dict)
                {
                    if (item.Key == key)
                    {
                        filteredDict.Add(key, item.Value);
                    }
                }
            }

            return filteredDict;
        }
    }
}
