using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegateProj
{
    [TestClass]
    public class UnitTest1
    {
        public void DoWork()
        {
            Debug.WriteLine($"inside DoWork() thread id = {System.Threading.Thread.CurrentThread.ManagedThreadId}");
        }

        delegate void CallableObj();

        [TestMethod]
        public void TestMethod01()
        {
            DoWork();
        }

        [TestMethod]
        public void TestMethod02()
        {
            CallableObj callableObj = new CallableObj(DoWork);
            callableObj.Invoke();
        }

        [TestMethod]
        public void TestMethod03()
        {
            Debug.WriteLine($"main thread {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            CallableObj callableObj = new CallableObj(DoWork);
            IAsyncResult asyncResult = callableObj.BeginInvoke(null, null);
            callableObj.EndInvoke(asyncResult);
        }

        private static void MyCallbackFn(IAsyncResult asyncResult)
        {
            Debug.WriteLine($"inside callback thread id = {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            // find the delegate object from asyncResult->asyncState
            var delegateObj = asyncResult.AsyncState as CallableObj;
            // finish the invocation of thread
            delegateObj.EndInvoke(asyncResult);
        }

        [TestMethod]
        public void TestMethod04()
        {
            Debug.WriteLine($"main thread id = {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            CallableObj callableObj = new CallableObj(DoWork);
            // make a callback object
            AsyncCallback asyncCallback = new AsyncCallback(MyCallbackFn);
            IAsyncResult asyncResult = callableObj.BeginInvoke(asyncCallback, callableObj);

            // notice that the BeginInvoke returns immediately in this thread - now we must wait
            //  for the thread to finish
            // just call async-wait for handle for now. other circumstances would wait on data or something
            asyncResult.AsyncWaitHandle.WaitOne(); // blocks self and waits for other thread
        }
    }
}
