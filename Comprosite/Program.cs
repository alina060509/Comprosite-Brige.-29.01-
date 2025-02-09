using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Program
{
    public static void Main(string[] args)
    {
        Folder root = new Folder("Мой Комп");
        Folder documents = new Folder("Документы");
        documents.Add(new File("Реферат.docx"));
        documents.Add(new File("Список.xlsx"));

        Folder music = new Folder("Музыка");
        music.Add(new File("Песня.mp3"));

        root.Add(documents);
        root.Add(music);
        root.Add(new File("README.txt"));
    }
}
public interface IFileSystem
{
    string Name { get; }
    void Show();
}

public class File : IFileSystem
{
    public string Name { get; }

    public File(string name)
    {
        Name = name;
    }

    public void Show(string indent)
    {
        Console.WriteLine("\tФайл: " + Name);
    }

    public void Show()
    {
        throw new NotImplementedException();
    }
}

public class Folder : IFileSystem
{
    public string Name { get; }
    private List<IFileSystem> _children = new List<IFileSystem>();

    public Folder(string name)
    {
        Name = name;
    }

    public void Add(IFileSystem item)
    {
        _children.Add(item);
    }

    public void Remove(IFileSystem item)
    {
        _children.Remove(item);
    }

    public void Show()
    {
        Console.WriteLine("\tПапка: " + Name);
        foreach (var item in _children)
        {
            item.Show(" ");
        }
    }
}

