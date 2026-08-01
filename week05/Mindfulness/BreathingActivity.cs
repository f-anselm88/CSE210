using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = GetEndTime();
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            AnimateBreath(growing: true);
            Console.Write("Breathe out...");
            AnimateBreath(growing: false);
        }

        DisplayEndingMessage();
    }

    // Creativity addition: instead of a plain countdown, the breath cue
    // grows or shrinks with dots, giving a visual pacing cue that mirrors
    // an actual inhale/exhale rather than just a number ticking down.
    private void AnimateBreath(bool growing)
    {
        int steps = 5;
        for (int i = 0; i < steps; i++)
        {
            int dots = growing ? i + 1 : steps - i;
            Console.Write(new string('.', dots));
            Thread.Sleep(800);
            Console.Write(new string('\b', dots) + new string(' ', dots) + new string('\b', dots));
        }
        Console.WriteLine();
    }
}
