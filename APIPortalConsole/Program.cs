using System;
using APIPortalLibrary;
using APIPortalLibrary.Models.Store;


namespace APIPortalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskAllApis = Go.AllApis();

            AllApis allApis;

            allApis = taskAllApis.Result;

            Console.WriteLine("Get All Apis:");
            Console.WriteLine("List : " + allApis.list);
            Console.WriteLine("Count : " + allApis.count);
            Console.WriteLine("Next : " + allApis.next);
            Console.WriteLine("Previous : " + allApis.previous);
            Console.WriteLine("Pagination limit : " + allApis.pagination.limit);
            Console.WriteLine("Pagination offset : " + allApis.pagination.offset);
            Console.WriteLine("Pagination total : " + allApis.pagination.total);
        }
    }
}
