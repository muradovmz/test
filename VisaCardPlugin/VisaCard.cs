using FFFFPluginBase;
using System;

namespace VisaCardPlugin;

public class VisaCard: IFFFFPlugin
{
    public void MakePayment()
    {
        Console.WriteLine("The payment is done by VisaFFFF");
    }

}
