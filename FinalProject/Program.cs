namespace FinalProject
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Logger.Log("Application Start Successfully");
            ATMCheck myatm = new ATMCheck();
            myatm.CheckATM();


            Functions depositamount = new Functions();
            depositamount.ChooseOperation();


            Logger.Log("Application Ends Successfully");
        }
    }
}
