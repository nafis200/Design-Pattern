<!-- problem -->


using System;
using System.Collections.Generic;

public interface Isend
{
    public void sendMessage();
}

public interface Ilog
{
    public void log();
}

public interface Isave
{
    public void Save();
}




public class EmailNotify : Isend, Isave, Ilog
{
    public string Email { get; set; }
    public void sendMessage()
    {
        Console.WriteLine($"Sending Email to {Email}");
    }

    public void log()
    {
        Console.WriteLine("Log Email");
    }

    public void Save()
    {
        Console.WriteLine("Email Save");
    }
}



public class SmsNotify : Isend, Isave, Ilog
{
    public string MobileNumber { get; set; }

    public void sendMessage()
    {
        Console.WriteLine($"Sending SMS to {MobileNumber}");
    }

    public void log()
    {
        Console.WriteLine("Log Email");
    }

    public void Save()
    {
        Console.WriteLine("Email Save");
    }
}

public class PushNotify : Isend, Ilog
{
    public string Token { get; set; }

    public void sendMessage()
    {
        Console.WriteLine($"Sending Token to {Token}");
    }

    public void log()
    {
        Console.WriteLine("Log Email");
    }

}

public class NotifyContext
{
    public Isend Send { get; set; }
    public Ilog log { get; set; }

    public Isave save { get; set; }

    public NotifyContext(Isend Send, Ilog log, Isave save)
    {
        this.Send = Send;
        this.log = log;
        this.save = save;
    }

    public void Process()
    {
        Send.sendMessage();
        log.log();
        if (save != null)
        {
            save.Save();
        }
    }
}


class Program
{
    static void Main(string[] args)
    {

        EmailNotify Emailnotifies = new EmailNotify{ Email= "nafisahamed14gmail.com" };
        SmsNotify smsnotifies = new SmsNotify{ MobileNumber = "01922208141" };
        PushNotify pushnotifies = new PushNotify{ Token = "abc" };


        NotifyContext emailnotifier = new NotifyContext(Emailnotifies,Emailnotifies,Emailnotifies);
        
        NotifyContext smsnotifier = new NotifyContext(smsnotifies,smsnotifies,smsnotifies);

        NotifyContext pushnotifier = new NotifyContext(pushnotifies, pushnotifies, null);

        IList<NotifyContext> notifies = new List<NotifyContext>();
        notifies.Add(emailnotifier);
        notifies.Add(smsnotifier);
        notifies.Add(pushnotifier);

        foreach (var item in notifies)
        {    
             item.Process();
        }

    }
}


<!-- class e ki ki add kora lagbe sob dekhe dekhe implement korte hoy boring -->