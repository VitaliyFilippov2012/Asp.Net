using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBookLibrary;

namespace PhoneBookWebApp.Controllers
{
    public class PhoneBooksController : Controller
    {
        private readonly IPhoneDictionary _phoneDictionary;

        public PhoneBooksController(IPhoneDictionary phoneDictionary)
        {
            _phoneDictionary = phoneDictionary;
        }

        [HttpGet]
        [Route("TS")]
        public IList<PhoneBooks> GetBooks()
        {
            return _phoneDictionary.GetPhoneBooks();
        }

        [HttpGet]
        [Route("TS/{id}")]
        public IActionResult GetPhoneBook(Guid id)
        {
            var phoneBook = _phoneDictionary.GetPhoneBookById(id);
            if (phoneBook == null)
                return NotFound();

            return Ok(phoneBook);
        }

        [HttpPut]
        [Route("TS")]
        public IActionResult PutPhoneBook([FromBody]PhoneBooks phoneBook)
        {
            try
            {
                _phoneDictionary.Update(phoneBook.Id, phoneBook.Surname, phoneBook.TelephoneNumber);
            }
            catch (DbUpdateConcurrencyException)
            {

            }
            return StatusCode(200);
        }

        [HttpPost]
        [Route("TS")]
        public IActionResult PostPhoneBook([FromBody]PhoneBooks phoneBook)
        {
            if (phoneBook == null)
                return StatusCode(400);
            try
            {
                _phoneDictionary.Add(phoneBook.Surname, phoneBook.TelephoneNumber);
            }
            catch (DbUpdateException)
            {
                return StatusCode(409);
            }
            return StatusCode(204);
        }

        [HttpDelete]
        [Route("TS/{id}")]
        public IActionResult DeletePhoneBook(Guid id)
        {
            try
            {
                _phoneDictionary.Delete(id);
            }
            catch (DbUpdateException)
            {
                return StatusCode(409);
            }

            return Ok(200);
        }
    }
}