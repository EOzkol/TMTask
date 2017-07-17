using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElifOzkolTMTask.Models
{
    public class FizzBuzzResult
    {
        public String result;
        public FizzBuzzResultSummary summary;
        public FizzBuzzResult(String result, FizzBuzzResultSummary summary)
        {
            this.result = result;
            this.summary = summary;
        }

    }

    public class FizzBuzzResultSummary
    {

        public String fizz;
        public String buzz;
        public String fizzbuzz;
        public String integer;
        public FizzBuzzResultSummary(String fizz,String buzz,String fizzbuzz,String integer)
        {
            this.fizz = fizz;
            this.buzz = buzz;
            this.fizzbuzz = fizzbuzz;
            this.integer = integer;
        }

    }
}