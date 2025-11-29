using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
    ) { }

    protected override void ExecuteActivity()
    {
        long startTime = DateTimeOffset.Now.ToUnixTimeSeconds();
        long endTime = startTime + _duration;

        while (DateTimeOffset.Now.ToUnixTimeSeconds() < endTime)
        {
            long remaining = endTime - DateTimeOffset.Now.ToUnixTimeSeconds();
            if (remaining <= 0) break;

            Console.WriteLine("Breathe in...");
            int pauseIn = (int)Math.Min(3, remaining);
            if (pauseIn > 0) { ShowCountdown(pauseIn); }
            
            remaining = endTime - DateTimeOffset.Now.ToUnixTimeSeconds();
            if (remaining <= 0) break;

            Console.WriteLine("Breathe out...");
            int pauseOut = (int)Math.Min(4, remaining);
            if (pauseOut > 0) { ShowCountdown(pauseOut); }
        }
    }
}