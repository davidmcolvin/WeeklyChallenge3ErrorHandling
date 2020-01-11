using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;

namespace ConsoleUI
{
  class Program
  {
    static void Main(string[] args)
    {
      PaymentProcessor paymentProcessor = new PaymentProcessor();
      for (int i = 0; i <= 10; i++)
      {
        TransactionModel result;
        try
        {
          result = paymentProcessor.MakePayment($"Demo{ i }", i);

          if (result != null)
          {
            Console.WriteLine(result.TransactionAmount);
          }
          else
          {
            Console.WriteLine($"Null value for item {i}");
          }
        }
        catch (IndexOutOfRangeException ex)
        {
          Console.WriteLine("Skipped invalid record");
        }
        catch (FormatException ex) when (i != 5)
        {
          var message = "Formatting Issue";
          Exception myEx = ex.InnerException;
          while (myEx != null)
          {
            message += " " + myEx.Message;
            myEx = myEx.InnerException;
          }
          Console.WriteLine(message);
        }
        catch (Exception)
        {
          Console.WriteLine($"Payment skipped for payment with {i} items");
        }
      }
      Console.ReadLine();
    }
  }
}
