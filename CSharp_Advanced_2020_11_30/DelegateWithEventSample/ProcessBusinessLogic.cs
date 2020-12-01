using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateWithEventSample
{

    public delegate void Notify();

    public class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted;

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            //Mach was

            OnProcessCompleted();
        }

        public virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke();
        }
    }


    public class ProcessBusinessLogic2
    {
        public event EventHandler ProcessCompleted;

        public event EventHandler ProcessCompletedNew;

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");


            OnProcessCompleted(EventArgs.Empty);


            MyEventArg myEventArg = new MyEventArg();
            myEventArg.Uhrzeit = DateTime.Now;

            OnProcessCompletedNew(myEventArg);
        }

        public virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }

        public virtual void OnProcessCompletedNew(MyEventArg e)
        {
            ProcessCompletedNew?.Invoke(this, e);
        }
    }


    public class MyEventArg : EventArgs
    {
        public DateTime Uhrzeit { get; set; }
    }
}



