using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace RedisConsoleApp
{
    class Program
    {
        static RedisClient client = new RedisClient("127.0.0.1", 6379);
        static void Main(string[] args)
        {
            Nlog.NLogHelper.Instance.Info("Redis数据类型!");
            //StringTest();
            //HashTest();
            //QueueTest();
            SetTest();
        }

        private static void StringTest()
        {

            try
            {
                Console.WriteLine("************字符串类型************");
                client.Set<string>("name", "husanshao53");
                string username = client.Get<string>("name");
                Console.WriteLine(username);

                Nlog.NLogHelper.Instance.Info("Redis数据存储!");

                UserInfo userInfo = new UserInfo { UserName = "张三", UserPwd = "123" };
                client.Set<UserInfo>("userinfo", userInfo);
                UserInfo user = client.Get<UserInfo>("userinfo");
                Console.WriteLine(user.UserName);


                List<UserInfo> list = new List<UserInfo>
                {
                    new UserInfo { UserName="李四",UserPwd="1234"},
                    new UserInfo { UserName="王五",UserPwd="12345"}
                };
                client.Set<List<UserInfo>>("list", list);
                List<UserInfo> userInfoList = client.Get<List<UserInfo>>("list");
                foreach (UserInfo u in userInfoList)
                {
                    Console.WriteLine(u.UserName);
                }

            }
            catch (Exception ex)
            {
                Nlog.NLogHelper.Instance.Error(ex.Message);
            }
        }

        private static void HashTest()
        {
            Nlog.NLogHelper.Instance.Info("hash");
            Console.WriteLine("***************Hash**********");
            client.SetEntryInHash("userInfoId","name","husanshao53");
            var lstKeys = client.GetHashKeys("userInfoId");
            lstKeys.ForEach(k=>Console.WriteLine(k));
            var lstValues = client.GetHashValues("userInfoId");
            lstValues.ForEach(v => Console.WriteLine(v));
            client.Remove("userInfoId");
            
        }

        private static void QueueTest()
        {
            Nlog.NLogHelper.Instance.Info("Queue队列");
            Console.WriteLine("***********队列 先进先出************");
            client.EnqueueItemOnList("test", "杨飞");
            client.EnqueueItemOnList("test", "龙印通");
            long length = client.GetListCount("test");
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(client.DequeueItemFromList("test"));
            }
            Console.WriteLine("******** 栈 先进后出************");
            client.PushItemToList("name1","唐罗");
            client.PushItemToList("name1","陆峰");
            long length1 = client.GetListCount("name1");
            for (int i = 0; i < length1; i++)
            {
                Console.WriteLine(client.PopItemFromList("name1"));
            }
        }

        private static void SetTest()
        {
            client.AddItemToSet("TripSCM", "方俊盛");
            client.AddItemToSet("TripSCM","康田");
            client.AddItemToSet("TripSCM","晁宝生");
            client.AddItemToSet("TripSCM","张达");
            client.AddItemToSet("TripSCM","杨文俊");
            client.AddItemToSet("TripSCM","蔡浚良");
            HashSet<string> hashset1 = client.GetAllItemsFromSet("TripSCM");
            Console.WriteLine("***********测试数据*******************");
            ConsoleHashSetInfo(hashset1);
        }

        private static void ConsoleHashSetInfo(HashSet<string> hs)
        {
            foreach (var item in hs)
            {
                if (item == "张达")
                    continue;
                Console.WriteLine(item);
            }
        }
    }

    public class UserInfo
    {
        public string UserName { get; set; }
        public string UserPwd { get; set; }
    }
}
