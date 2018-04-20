using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LR
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // 初始化字色
                Console.ForegroundColor = ConsoleColor.White;

                // 宣告參數
                Random r = new Random();// 亂數
                int[] num = new int[6];// 儲存當期得獎數字的陣列
                int prize = 0;// 玩家簽下的號碼
                int score = 0;// 玩家中獎數

                Console.WriteLine("請簽下這期大樂透號碼(1碼 1~42)" + "\r\n");

                // 直到玩家輸入正確才Break  否則都到Catch
                while (true)
                {
                    try
                    {
                        // 不能轉換即到catch
                        Int32.TryParse(Console.ReadLine(), out prize);

                        // 非1~42即到Catch
                        if (prize >= 1 && prize <= 42)
                        {
                            // 空行美觀
                            Console.WriteLine("\r\n");

                            // 好東西  不知道功能上網查
                            break;
                        }
                        else
                        {
                            // 好東西2號  同上
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        // 王八蛋
                        Console.WriteLine("請正確輸入" + "\r\n");
                    }
                }

                // 利用巢狀迴圈產生10*6組號碼
                for (int i = 0; i < 10; i++)
                {
                    // 刷新字色
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("第" + (i + 1) + "張樂透" + "\r\n");
                    for (int j = 0; j < 6; j++)
                    {
                        // 將開獎號碼存進num陣列
                        num[j] = r.Next(1, 43);

                        // 比對玩家是否得獎
                        if (num[j] == prize)
                        {
                            // 得獎就加分並把字變紅
                            score++;
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            // 沒得獎字太白
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        // 用String組合的方式print出號碼
                        Console.WriteLine("第" + (j + 1) + "組號碼:" + num[j]);
                    }

                    // 換行for美觀
                    Console.WriteLine("\r\n");

                    // 暫停一下會比較有開獎的fu
                    Thread.Sleep(500);
                }

                // 記得刷新字的顏色
                Console.ForegroundColor = ConsoleColor.White;

                // 看玩家有無得獎
                if (score > 0)
                {
                    Console.WriteLine("這次您共中了 " + score + " 次獎！" + "\r\n");
                }
                else
                {
                    Console.WriteLine("可憐");
                }

                // 判斷使用者輸入是否為n 是即跳出迴圈
                Console.WriteLine("輸入n離開或按Enter繼續");
                if (Console.ReadKey().Key == ConsoleKey.N)
                {
                    break;
                }

                Console.Clear();
            }
        }
    }
}
