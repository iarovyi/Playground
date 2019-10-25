using static Bullseye.Targets;
using System;
using static SimpleExec.Command;

class Program
{
    static void Main(string[] args)
    {
        //Target("default", () => System.Console.WriteLine("Hello, world!"));
		Target("default", DependsOn("drink-tea", "walk-dog"));
		Target("make-tea", () => Console.WriteLine("Tea made."));
		Target("drink-tea", DependsOn("make-tea"), () => Console.WriteLine("Ahh... lovely!"));
		Target("walk-dog", () => Console.WriteLine("Walkies!"));
		Target("eat-biscuits", ForEach("digestives", "chocolate hob nobs"),
			biscuits => Console.WriteLine($"Mmm...{biscuits}! Nom nom."));
	
        RunTargetsAndExit(args);
    }
}