using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EncryptService.Models
{
    public class EncryptModel
    {
        public int Id { get; set; }
        //Символ, который заменяется
        public string OldSymbol { get; set; }
        //Сисвол, на который заменяется
        public string NewSymbol { get; set; }        
    }
}