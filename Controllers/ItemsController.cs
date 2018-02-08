using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller

    {
        [HttpGet("/items")]
        public ActionResult Index()
        {
            List<Item> allItems = Item.GetAll();
            Console.WriteLine("List is how many items long?" + allItems.Count);
            return View(allItems);
        }

        // [HttpGet("/items/new")]
        // public ActionResult CreateForm()
        // {
        //     return View();
        // }

        // [HttpPost("/items")]
        // public ActionResult Create()
        // {
        //   Console.WriteLine("Got into /items!");
        //   Item newItem = new Item (Request.Form["new-item"]);
        //   List<Item> allItems = Item.GetAll();
        //   return View("Index", allItems);
        //   // return View();
        // }

        // [HttpPost("/items")]
        // public ActionResult Create()
        // {
        //   Item newItem = new Item (Request.Form["new-item"]);
        //   List<Item> allItems = Item.GetAll();
        //   return View("Index", allItems);
        //   // return View();
        // }

        // [HttpGet("/categories/{categoryId}/items/new")]
        // public ActionResult CreateForm(int categoryId)
        // {
        //     Dictionary<string, object> model = new Dictionary<string, object>();
        //     Category foundCategory = Category.Find(categoryId);
        //     List<Item> allItems = foundCategory.GetItems();
        //     model.Add("category", foundCategory);
        //     model.Add("items", allItems);
        //     return View(model);
        // }

        // [HttpGet("/categories/{categoryId}/items/new")]
        // public ActionResult CreateForm(int categoryId)
        // //  public ActionResult CreateItemForm(int categoryId)
        //  {
        //     Dictionary<string, object> model = new Dictionary<string, object>();
        //     Category category = Category.Find(categoryId);
        //     Console.WriteLine("Throw the details! CategoryId: " + categoryId);
        //     // return View(category); // revert
        //     return View("CreateItemForm", category); // should pass to new item form
        //     // return View("Index", model);
        //  }

         [HttpGet("/categories/{categoryId}/items/{itemId}")]
         public ActionResult Details(int categoryId, int itemId)
         {
            Item item = Item.Find(itemId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            Category category = Category.Find(categoryId);
            model.Add("item", item);
            model.Add("category", category);
            // return View("Items", item);
            // return View("Index");
            return View(model);
         }

        [HttpGet("/items/{id}")]
        public ActionResult Details(int id)
        {
            Item item = Item.Find(id);
            Dictionary<string, object> model = new Dictionary<string, object>();
            // Category category = Category.Find(item.GetCategoryId());
            Category category = Category.Find(item.GetId());

            model.Add("item", item);
            model.Add("category", category);
            return View(item);
        }

        // [HttpGet("/items/{id}")]
        // public ActionResult Details(int id)
        // {
        //     Item item = Item.Find(id);
        //     return View(item);
        // }

        [HttpPost("/items/delete")]
        public ActionResult DeleteAll()
        {
            Item.ClearAll();
            return View();
        }
    }
}
