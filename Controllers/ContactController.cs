using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;

namespace AddressBook.Controllers
{
  public class ContactController : Controller
  {
    [HttpGet("/contact")]
    public ActionResult Index()
    {
      List<Contact> allContact = Contact.GetAll();
      return View(allContact);
    }

    [HttpGet("/contact/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/contact")]
    public ActionResult Create()
    {
      Contact newContact = new Contact(Request.Form["contact-name"]);
      List<Contact> allContact = Contact.GetAll();
      return View("Index", allContact);
    }

    [HttpGet("/contact/{id}")]
    public ActionResult Details(int id)
    {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(id);
        List<Address> contactAddress = selectedContact.GetAddress();
        model.Add("contact", selectedContact);
        model.Add("address", contactAddress);
        return View(model);
    }

    [HttpPost("/address")]
    public ActionResult CreateAddress()
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Contact foundContact = Contact.Find(Int32.Parse(Request.Form["Contact-id"]));
      string addressDescription = Request.Form["address-description"];
      Address newAddress = new Address(addressDescription);
      foundContact.AddAddress(newAddress);
      List<Address> contactAddress = foundContact.GetAddress();
      model.Add("address", contactAddress);
      model.Add("contact", foundContact);
      return View("Details", model);
    }
  }
}
