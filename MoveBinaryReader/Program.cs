// See https://aka.ms/new-console-template for more information

using MoveBinaryReader;
using MoveBinaryReader.Models;
using ModuleHandle = MoveBinaryReader.Models.ModuleHandle;

using var fh = File.OpenRead("btc.mv");

var bytes = new byte[fh.Length];
fh.Read(bytes, 0, bytes.Length);

IMoveReader moveFileReader = new MoveReader(bytes);

if (!moveFileReader.TryReadModel<FileHeader>(out var fileHeader))
{
    Console.WriteLine("could not read fileheader");
    Console.ReadKey();
}

if (!moveFileReader.TryReadModelCollection<TableHeader>(out var headers, fileHeader.TableCount))
{
    Console.WriteLine("could not read tableHeader");
    Console.ReadKey();
}