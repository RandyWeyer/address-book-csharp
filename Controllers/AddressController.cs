using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    public class AddressController : Controller
    {
      [HttpGet("/address")]
      public ActionResult Index()
      {
          List<Address> allAddress = Address.GetAll();
          return View(allAddress);
      }

      [HttpGet("/address/new")]
      public ActionResult CreateForm()
      {
          return View();
      }
      [HttpGet("/contact/{contactId}/address/new")]
      public ActionResult CreateForm(int contactId)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact contact = Contact.Find(contactId);
        return View(contact);
      }
      [HttpGet("/contact/{contactId}/address/{addressId}")]
       public ActionResult Details(int contactId, int addressId)
       {
          Address address = Address.Find(addressId);
          Dictionary<string, object> model = new Dictionary<string, object>();
          Contact contact = Contact.Find(contactId);
          model.Add("address", address);
          model.Add("contact", contact);
          return View(address);
       }

    }
}
