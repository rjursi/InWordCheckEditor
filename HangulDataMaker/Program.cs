using System.Threading;

namespace HangulDataMaker
{
    class Program
    {


        static void Main(string[] args)
        {
            WikiWordParser parser = new WikiWordParser();
            ExcelDataMaker dataMaker = new ExcelDataMaker();

            parser.WebDataLoad();

            dataMaker.DataWrite(parser);

            Thread.Sleep(1500);

        }
    }
}
