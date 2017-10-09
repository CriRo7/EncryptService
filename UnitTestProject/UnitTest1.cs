using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using EncryptService.Models;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Тестирование метода щифолвания с помощью linq
        /// </summary>
        [TestMethod]
        public void TestEncryptWithLinq()
        {
            //arrange
            string text = "привет";
            EFDbContext db = new EFDbContext();
            //act           

            var list = text.Where(t => db.EncryptModels.Any(m => m.OldSymbol.Equals(t)));
            
            string resString = String.Join("", list);
            //assert
            Assert.AreEqual("поцэъм", resString);
        }
    }
}
