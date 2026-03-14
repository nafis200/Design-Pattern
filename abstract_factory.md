<!-- bad practice for factory builders  class which is made-->


using System;

public interface Isend
{
    void sendMessage();
}

public interface Ilog
{
    void log();
}

public interface Isave
{
    void Save();
}

public class EmailNotify : Isend, Isave, Ilog
{
    public string Email { get; set; }

    public void sendMessage() => Console.WriteLine($"Sending Email to {Email}");
    public void log() => Console.WriteLine("Log Email");
    public void Save() => Console.WriteLine("Email Saved");
}

public class SmsNotify : Isend, Isave, Ilog
{
    public string MobileNumber { get; set; }

    public void sendMessage() => Console.WriteLine($"Sending SMS to {MobileNumber}");
    public void log() => Console.WriteLine("Log SMS");
    public void Save() => Console.WriteLine("SMS Saved");
}

public class PushNotify : Isend, Ilog
{
    public string Token { get; set; }

    public void sendMessage() => Console.WriteLine($"Sending Push Notification to {Token}");
    public void log() => Console.WriteLine("Log Push");
}

public class NotifyContext
{
    public Isend Send { get; set; }
    public Ilog log { get; set; }
    public Isave save { get; set; }

    public NotifyContext(Isend send, Ilog log, Isave save)
    {
        Send = send;
        this.log = log;
        this.save = save;
    }

    public void Process()
    {
        Send.sendMessage();
        log.log();
        save?.Save();
    }
}

public interface INotificationContextCreator
{
    NotifyContext Create();
}

public class EmailNotificationContextCreator : INotificationContextCreator
{
    public NotifyContext Create()
    {
        var email = new EmailNotify { Email = "n@gmail.com" };
        return new NotifyContext(email, email, email);
    }
}

public class SmsNotificationContextCreator : INotificationContextCreator
{
    public NotifyContext Create()
    {
        var sms = new SmsNotify { MobileNumber = "12345" };
        return new NotifyContext(sms, sms, sms);
    }
}

public class PushNotificationContextCreator : INotificationContextCreator
{
    public NotifyContext Create()
    {
        var push = new PushNotify { Token = "abc" };
        return new NotifyContext(push, push, null); 
    }
}

class Program
{
    static void Main(string[] args)
    {
        INotificationContextCreator emailCreator = new EmailNotificationContextCreator();
        NotifyContext emailContext = emailCreator.Create();
        emailContext.Process();

        Console.WriteLine();

        INotificationContextCreator smsCreator = new SmsNotificationContextCreator();
        NotifyContext smsContext = smsCreator.Create();
        smsContext.Process();

        Console.WriteLine();

        INotificationContextCreator pushCreator = new PushNotificationContextCreator();
        NotifyContext pushContext = pushCreator.Create();
        pushContext.Process();
    }
}