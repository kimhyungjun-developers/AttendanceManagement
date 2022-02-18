using Model.DataContext;
using Model.DataServices;
using Model.Messages;
using System;
using System.IO;
using System.Text;
using Xunit.Abstractions;

namespace UnitTest.Infrastructures;

public abstract class TestBase : IDisposable
{
    protected TestBase(ITestOutputHelper output)
    {
        Output = output;
        var dataContext = new SQLiteDataContext();
        var messageGenerator = new MessageGenerator();
        dataContext.Database.EnsureCreated();
        DataContext = dataContext;
        DataService = new DataService(dataContext, messageGenerator);
        MessageGenerator = messageGenerator;

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    protected ITestOutputHelper Output { get; }

    protected DataContextBase DataContext { get; private set; } = null!;

    protected IDataService DataService { get; private set; } = null!;

    protected IMessageGenerator MessageGenerator { get; private set; } = null!;

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        DataService.Dispose();
    }

    protected static string GetRandomString() => Guid.NewGuid().ToString("N");

    protected void AddRangeWithIdentityInsert<T>(string _, T[] addDatas) where T : class
    {
        // SQLiteでは常にIdentityInsertが出来るらしい
        DataContext.Set<T>().AddRange(addDatas);
    }

    protected static Stream GetStream(string[] contents, Encoding encoding)
    {
        var stream = new MemoryStream();
        using var writer = new StreamWriter(stream, encoding, leaveOpen: true);
        foreach (var content in contents)
            writer.WriteLine(content);
        writer.Flush();
        stream.Seek(0, SeekOrigin.Begin);
        return stream;
    }
}