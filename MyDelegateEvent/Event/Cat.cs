using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{   

    /// <summary>
    /// 事件的发布者
    /// </summary>
    public class Cat
    {
        public void Miao()
        {   
            //观察者模式
            Console.WriteLine("{0} Miao",this.GetType().Name);
            new Mouse().Run();
            new Dog().Wang();
            new Baby().Cry();
            new Brother().Turn();
            new Mother().Wispher();
            new Father().Rora();
            new Neighbor().Awake();
            new Stealer().Hide();
        }
        public Action MiaoAction;
        public void MiaoActionMethod()
        {
            Console.WriteLine("{0} MiaoActionMethod", this.GetType().Name);
            if (this.MiaoAction != null)
                MiaoAction.Invoke();
        }
        /// <summary>
        /// 事件是委托的一个实例，委托是一种类型
        /// </summary>
        public event Action MiaoEvent;

        public void MiaoEventMethod()
        {
            Console.WriteLine("{0} MiaoEventMethod",this.GetType().Name);
            if (this.MiaoEvent != null)
                MiaoEvent.Invoke();
        }
        private List<IObject> _Object = new List<IObject>();
        public void AddObject(IObject iObject)
        {
            this._Object.Add(iObject);
        }
    }
}
