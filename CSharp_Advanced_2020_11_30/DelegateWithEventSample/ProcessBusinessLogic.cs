using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DelegateWithEventSample
{

    public delegate void Notify();
    public delegate void MyProcess(int percent);

    public class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted;
        public event MyProcess Processing;

        public async void StartProcess()
        {
            Console.WriteLine("Process Started!");
            //Mach was

            OnProcessing(43);
            //await Task.Delay(500);
            OnProcessing(52);
            //await Task.Delay(500);
            OnProcessing(64);
            //await Task.Delay(500);
            OnProcessing(65);
            await Task.Delay(500);
            OnProcessing(99);


            //bin fertig
            OnProcessCompleted();
        }

        public virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke();
        }

        public virtual void OnProcessing(int percentCount)
        {
            Processing?.Invoke(percentCount);
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



