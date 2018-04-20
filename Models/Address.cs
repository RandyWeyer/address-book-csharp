using System.Collections.Generic;
using System;

namespace AddressBook.Models
{
  public class Address
  {
    private string _street;
    private string _city;
    private string _state;
    private string _zipcode;
    private int _id;
    private static List<Address> _instances = new List<Address>{};
    public static int addressCounter;

    public Address (string street, string city, string state, string zipcode)
    {
      _street = street;
      _city = city;
      _state = state;
      _zipcode = zipcode;
      _instances.Add(this);
      _id = addressCounter;
      addressCounter++;
    }
    public string GetStreet()
    {
      return _street;
    }
    public void SetStreet(string newStreet)
    {
      _street = newStreet;
    }
    public string GetCity()
    {
      return _city;
    }
    public void SetCity(string newCity)
    {
      _city = newCity;
    }
    public string GetState()
    {
      return _state;
    }
    public void SetState(string newState)
    {
      _state = newState;
    }
    public string GetZipcode()
    {
      return _zipcode;
    }
    public void SetZipcode(string newZipcode)
    {
      _zipcode = newZipcode;
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
