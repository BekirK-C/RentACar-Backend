using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        // readonly constructor'da set edilebilir.
        // set kullanmayarak yazılımda standardizeyi constructor ile sağlamış oluyoruz.
        public Result(bool ısSuccess, string message) : this(ısSuccess)  // this bulunduğu class'ı ifade eder. 
        {
            Message = message;
         // IsSuccess = ısSuccess;   bu kodu tekrar etmemek adında 2.overload ile bu constructor'da :this(success) şeklinde çalıştırıyoruz.
        }
        public Result(bool ısSuccess)
        {
            IsSuccess = ısSuccess;
        }
        public bool IsSuccess { get; }

        public string Message { get; }
    }
}