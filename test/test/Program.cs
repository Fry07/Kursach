/*
Demonstration program simulates a dynamic requirement by passing the current time into the chain of handlers. The handler that will accept responsibility is dependant how far through the current minute we have progressed.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Chain_Example4
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Set up a chain of candidate handlers to handle the
            request. Chain will be (1st considered -> last):
            ConcreteHandler1, ConcreteHandler2. */

            HandlerBase chain = new ConcreteHandler3();
            HandlerBase more = new ConcreteHandler2();
            more.Successor = chain;
            chain = new ConcreteHandler1();
            chain.Successor = more;
            // hand the request to the chain
            Console.WriteLine(chain.SayWhen(DateTime.Now));
            Console.ReadKey();
        }
    }

    public interface IHandler
    {
        // properties
        HandlerBase Successor { set; }
    }

    // --- Abstract Handler
    abstract public class HandlerBase
    {
        // fields
        protected HandlerBase _successor;
        // properties
        public HandlerBase Successor
        {
            set { _successor = value; }
        }
        // methods
        abstract public string SayWhen(DateTime localTime);
    }

    // --- Concrete handlers
    public class ConcreteHandler1 : HandlerBase
    {
        // methods
        override public string SayWhen(DateTime localTime)
        {
            if (localTime.Second < 15)
                return String.Format("I am {0}.\nThe time is {1:T}\nWe are just starting on a shiny new minute.",
                                      this.ToString(), localTime);
            else
            {
                if (_successor != null)
                {
                    return _successor.SayWhen(localTime);
                }
                else
                    throw new ApplicationException("ChainOfResponsibility object exhausted all successors without call being handled.");
            }
        }
    }

    public class ConcreteHandler2 : HandlerBase
    {
        // methods
        override public string SayWhen(DateTime localTime)
        {
            if ((localTime.Second >= 15) &
               (localTime.Second < 45))
                return String.Format("I am {0}.\nThe time is {1:T}\nWe are into the middle half of this minute.",
                                      this.ToString(), localTime);
            else
            {
                if (_successor != null)
                {
                    return _successor.SayWhen(localTime);
                }
                else
                    throw new ApplicationException("ChainOfResponsibility object exhausted all successors without call being handled.");
            }
        }
    }


    public class ConcreteHandler3 : HandlerBase
    {
        // methods
        override public string SayWhen(DateTime localTime)
        {
            if ((localTime.Second >= 45) &
               (localTime.Second < 60))
                return String.Format("I am {0}.\nThe time is {1:T}\nWe are into the third quarter of this minute.",
                                      this.ToString(), localTime);
            else
            {
                if (_successor != null)
                {
                    return _successor.SayWhen(localTime);
                }
                else
                    throw new ApplicationException("ChainOfResponsibility object exhausted all successors without call being handled.");
            }
        }
    }
}

