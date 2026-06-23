using static FinalProject.ATMCheck;

namespace FinalProject
{
    internal class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Logger.Log("Application Start Successfully");
                ATMCheck myatm = new ATMCheck();
                Client current = myatm.CheckATM();


                Functions depositamount = new Functions(current);
                depositamount.ChooseOperation();


                Logger.Log("Application End Successfully");
            }
            catch (Exception ex)
            {
                Logger.Log($"Error {ex.Message}");
                Console.WriteLine($"SomethingWrong {ex.Message}");

            }
        }
    }
}

