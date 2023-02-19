using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class HttpResult
    {
        public string? Url { get; set; }
        public string? RequestBody { get; set; }
        public string? ResponseBody { get; set; }

        //http://test.com?user=max&pass=123456

        public string RewriteProperties(string querry)
        {
            if (querry.Contains("?") || querry != string.Empty)
            {
                string[] divQuerry = querry.Split('?');
                string firstPartOfQuerry = divQuerry[0];
                string secondPartOfQuerry = divQuerry[1];
                int positionOfFirstQuerry = 0;
                int positionOfSecondQuerry = 0;
                int lengthOfFirstQuerry = firstPartOfQuerry.Length;
                int lengthOfSecondQuerry = secondPartOfQuerry.Length;

                while (positionOfFirstQuerry <= lengthOfFirstQuerry)
                {
                    if (firstPartOfQuerry.Contains("users"))
                    {
                        positionOfFirstQuerry = firstPartOfQuerry.IndexOf("users") + "users".Length;
                        positionOfFirstQuerry++;
                    }
                    else
                    {
                        break;
                    }
                    while (firstPartOfQuerry[positionOfFirstQuerry].ToString() != "/")
                    {
                        StringBuilder sb1 = new StringBuilder(firstPartOfQuerry);
                        sb1[positionOfFirstQuerry] = 'X';
                        firstPartOfQuerry = sb1.ToString();
                        positionOfFirstQuerry++;
                    }
                    break;
                }
                while (positionOfSecondQuerry < lengthOfSecondQuerry - 1)
                {
                    positionOfSecondQuerry++;

                    if (secondPartOfQuerry[positionOfSecondQuerry] == '=')
                    {
                        positionOfSecondQuerry++;
                        while (secondPartOfQuerry[positionOfSecondQuerry] != '&' && positionOfSecondQuerry < lengthOfSecondQuerry - 1)
                        {
                            StringBuilder sb2 = new StringBuilder(secondPartOfQuerry);
                            sb2[positionOfSecondQuerry] = 'X';
                            secondPartOfQuerry = sb2.ToString();
                            positionOfSecondQuerry++;
                            if (positionOfSecondQuerry == lengthOfSecondQuerry - 1)
                            {
                                sb2[positionOfSecondQuerry] = 'X';
                                secondPartOfQuerry = sb2.ToString();
                            }
                        }
                    }
                }
                querry = firstPartOfQuerry + "?" + secondPartOfQuerry;
            }
            return querry;
        }

        public void SecureProperties()
        {
            Url = RewriteProperties(Url);
            RequestBody = RewriteProperties(RequestBody);
            ResponseBody = RewriteProperties(ResponseBody);
        }

        public void PrintRewritedProperties()
        {
            Console.WriteLine($"'Перетертый' Url: {Url} \n'Перетертый' RequestBody: {RequestBody} \n'Перетертый' ResponseBody: {ResponseBody} ");
        }
    }
}
