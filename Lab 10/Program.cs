using System;

public abstract class ParagraphStyle
{
    public string Text { get; set; }

    public ParagraphStyle(string text)
    {
        Text = text;
    }

    public abstract void Accept(IVisitor visitor);
}

public class RowStyle : ParagraphStyle
{
    public RowStyle(string text) : base(text) { }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class ColumnStyle : ParagraphStyle
{
    public ColumnStyle(string text) : base(text) { }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public interface IVisitor
{
    void Visit(RowStyle rowStyle);
    void Visit(ColumnStyle columnStyle);
}

public class StyleApplication : IVisitor
{
    public void Visit(RowStyle rowStyle)
    {
        Console.WriteLine("Applying row style...");
        Console.WriteLine(rowStyle.Text);
    }

    public void Visit(ColumnStyle columnStyle)
    {
        Console.WriteLine("Applying column style...");
        string[] words = columnStyle.Text.Split(' ');
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ParagraphStyle[] styles = new ParagraphStyle[] { 
            new RowStyle("This is a row style text."),
            new ColumnStyle("This is a column style text.") 
        };

        StyleApplication styleApplication = new StyleApplication();

        foreach (var style in styles)
        {
            style.Accept(styleApplication);
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}
