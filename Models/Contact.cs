using System.Collections.Generic;

namespace AddressBook.Models
{
  public class Contact
  {
    private static List<Contact> _instances = new List<Contact> {};
    private string _name;
    private int _id;
    private List<Address> _address;
    public static int contactCounter;

    public Contact(string contactName)
    {
      _name = contactName;
      _instances.Add(this);
      _id = contactCounter;
      _address = new List<Address>{};
      contactCounter++;
    }
    public List<Address> GetAddress()
    {
      return _address;
    }
    public void AddAddress(Address Address)
    {
      _address.Add(Address);
    }
    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }
    public static void Clear()
    {
      _instances.Clear();
    }
    public static Contact Find(int searchId)
    {
      return _instances[searchId];
    }
  }
}
