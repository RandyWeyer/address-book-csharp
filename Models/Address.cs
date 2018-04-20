using System.Collections.Generic;
using System;

namespace AddressBook.Models
{
  public class Address
  {
    private string _description;
    private int _id;
    private static List<Address> _instances = new List<Address>{};
    public static int addressCounter;

    public Address (string description)
    {
      _description = description;
      _instances.Add(this);
      _id = addressCounter;
      addressCounter++;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Address> GetAll()
    {
      return _instances;
    }
    public void Save()
    {
      _instances.Add(this);
    }
        public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Address Find(int searchId)
    {
      return _instances[searchId];
    }
  }
}
