//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Enumerator
//{
//   public class Friend
//    {
//        private string name { get; set; }
//        public string Name
//        {
//            get { return name; }
//            set { name = value; }
//        }
//        public Friend(string name)
//        {
//            this.name = name;
//        }
//    }
//    //IEnumerator
//    public class Friends : IEnumerable
//    {
//        private Friend[] friendarray;
//        public Friends()
//        {
//            friendarray = new Friend[]
//            {
//                new Friend("彭文芳"),
//                new Friend("李玲玲"),
//                new Friend("陆峰")
//            };
//        }
//        /// <summary>
//        /// 索引器
//        /// </summary>
//        /// <param name="index"></param>
//        /// <returns></returns>
//        public Friend this[int index]
//        {
//            get { return friendarray[index]; }

//        }
//        public int Count
//        {
//            get { return friendarray.Length; }
//        }
//        public IEnumerator<Friend> GetEnumerator()
//        {
//            return new FriendIterator<Friend>(this);
//        }
//    }
//    public class FriendIterator<Friend> :IEnumerator<Friend>
//    {
//        private readonly Friends friends;
//        private int index;
//        private Friend current;
//        internal FriendIterator(Friends friendcollection)
//        {
//            this.friends = friendcollection;
//        }
//        public Friend Current
//        {
//            get
//            {
//                return this.current;
//            }
//        }
//        public bool MoveNext()
//        {
//            if (index + 1 > friends.Count)
//            {
//                return false;
//            }
//            else
//            {
//                this.current = friends[index];
//                index++;
//                return true;
//            }
//        }
//        public void Reset()
//        {
//            index = 0;
//        }

//        public void Dispose() { }
//    }
//}
