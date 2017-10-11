using EncryptService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EncryptService.Controllers
{
    public class HomeController : Controller
    {
        //Через объект контекста данных получаю доступ к таблицам бд.
        private EFDbContext db;

        public HomeController()
        {
            db = new EFDbContext();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(string message)
        {
            try
            {                
                //Сохранение сообщения и времени получения в таблицу UserTextModels из бд. Выполнение шифрования и сохранение в св-во EncrMessage
                UserTextModel utm = new UserTextModel() { Message = message, EncrMessage = EncryptMethod(message), DateTime = DateTime.Now };
                db.UserTextModels.Add(utm);
                db.SaveChanges();

                var models = db.UserTextModels;
                //отправка модели в виде Json        
                return Json(new { Models = models});
            }
            catch (Exception ex)
            {
                //Вывести ошибку подключения к бд.
                return Json(ex.Message);
            }
           
        }

        /// <summary>
        /// Метод шифрует каждый символ сообщения на определенный из бд.
        /// </summary>
        /// <param name="text">Сообщение для шифрования</param>
        /// <returns></returns>
        public string EncryptMethod(string text)
        {
            //Объект StringBuilder, в который получим зашифрованное сообщение
            StringBuilder sb = new StringBuilder();
            try
            {
                //Для каждого символа сообщения text..
                foreach (var ch in text)
                {
                    //Для каждого символа из бд..
                    foreach (var em in db.EncryptModels)
                    {
                        //Если символ сообщения совпадает с символом из OldSymbol
                        if (em.OldSymbol.Equals(ch.ToString().ToLower()))
                        {
                            //То возьмем символ из NewSymbol и добавим к объекту StringBuilder
                            sb.Append(em.NewSymbol);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Вывести ошибку подключения к бд в виде текста.
                return ex.Message;
            }
            return sb.ToString();
        }

        public ActionResult Clear()
        {
            try
            {
                ViewBag.UserTextModels = null;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return HttpNotFound(ex.Message);
            }
        }
    }
}