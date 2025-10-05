using System;

interface IPrinter
{
    void Print(string message);
}

// Adaptee (existing class with incompatible interface)
class LegacyPrinter
{
    public void PrintText(string text)
    {
        Console.WriteLine("Legacy Printer Output: " + text);
    }
}

// Adapter converts LegacyPrinter to IPrinter
class PrinterAdapter : IPrinter
{
    private LegacyPrinter _legacyPrinter;

    public PrinterAdapter(LegacyPrinter legacyPrinter)
    {
        _legacyPrinter = legacyPrinter;
    }

    public void Print(string message)
    {
        _legacyPrinter.PrintText(message);
    }
}

// Client
class Program
{
    static void Main()
    {
        LegacyPrinter oldPrinter = new LegacyPrinter();
        IPrinter printer = new PrinterAdapter(oldPrinter);

        printer.Print("Hello, Adapter Pattern!");
    }
}
