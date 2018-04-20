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
       [HttpGet("/update")]
        public ActionResult Update()
        {
          List<Address> allAddress = Address.GetAll();
          int addressId = int.Parse((Request.Query["id"]));
          int searchCounter = 0;

          foreach (Address item in allAddress)
          {
            if (item.GetId() == addressId)
            {
              break;
            }
            searchCounter++;
          }
          return View(allAddress[searchCounter]);
        }

        [HttpPost("/update-submit")]
        public ActionResult UpdateSubmit()
        {
          List<Address> allAddress = Address.GetAll();
          int addressId = int.Parse((Request.Form["id"]));

          allAddress[addressId].SetStreet(Request.Form["street"]);
          allAddress[addressId].SetCity(Request.Form["city"]);
          allAddress[addressId].SetState(Request.Form["state"]);
          allAddress[addressId].SetZipcode(Request.Form["zipcode"]);

          return View("Index", allAddress);
        }

       [HttpGet("/delete")]
       public ActionResult Delete()
        {
          List<Address> allAddress = Address.GetAll();
          int addressId = int.Parse((Request.Query["id"]));

          foreach (Address item in allAddress)
          {
            if (item.GetId() == addressId)
            {
              allAddress.Remove(item);
              break;
            }
          }
          return View("Index", allAddress);
        }

    }
}
