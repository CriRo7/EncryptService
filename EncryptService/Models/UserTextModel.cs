using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EncryptService.Models
{
    public class UserTextModel
    {
        public int Id { get; set; }
        //Сообщение для шифрования
        public string Message { get; set; }
        //Сообщение после шифрования
        public string EncrMessage { get; set; }
        //Время получения сообщения для шифрования
        public DateTime DateTime { get; set; }
    }
}