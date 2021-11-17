using demo_linq.linq_detail;
using System;

namespace demo_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while (input != "x")
            {
                ClearConsole();
                HandleInput(input);
                ShowMenu();
                input = Console.ReadLine();
            }
        }

        private static void ClearConsole()
        {
            Console.Clear();
        }

        

        private static void ShowMenu()
        {
            Console.WriteLine($@"
                                                Demo app - enter x to exit
                                            1.  IEnumerable
                                            2.  IQueryable
                                            3.  First()
                                            4.  FirstOrDefault()
                                            5.  Single()
                                            6.  SingleOrDefault()
                                            7.  Reference
                                            8.  Count() vs Any()
                                            9.  IEnumerable Multi 
                                            10. IQueryable Multi
                                            11. Multi List
                                            12. CURD
                                            13. Multi Table

                               ");
        }


        private static void HandleInput(string input)
        {
            try
            {
                switch (input)
                {
                    case "1":
                        IEnumerableDetail.Show();
                        break;
                    case "2":
                        IQueryableDetail.Show();
                        break;
                    case "3":
                        FirstDetail.Show();
                        break;
                    case "4":
                        FirstOrDefaultDetail.Show();
                        break;
                    case "5":
                        SingleDetail.Show();
                        break;
                    case "6":
                        SingleOrDefaultDetail.Show();
                        break;
                    case "7":
                        ReferenceDetail.Show();
                        break;
                    case "8":
                        CountAndAnyDetail.Show();
                        break;
                    case "9":
                        IEnumerableMultiDetail.Show();
                        break;
                    case "10":
                        IQueryableMultiDetail.Show();
                        break;
                    case "11":
                        MultiListDetail.Show();
                        break;
                    case "12":
                        CURDDetail.Show();
                        break;
                    case "13":
                        MultiTablesDetail.Show();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("ERROR - {0} - {1}", ex.Message, ex.StackTrace?.ToString()));
            }
        }
    }
}
