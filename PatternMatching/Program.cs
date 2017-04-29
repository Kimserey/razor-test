using System;

namespace PatternMatching
{
    // Exception way
    //
    public class NoRecipientFoundException : Exception { }
    public class RecipientOccupiedException : Exception { }
    public class CommunicationProblemException : Exception { }

    public interface ISaySomething
    {
        void Say(string recipient, string content);
    }

    public class SaySomething : ISaySomething
    {
        public void Say(string recipient, string content)
        {
            throw new NoRecipientFoundException();
        }
    }

    // Pattern matching way
    //
    public abstract class SayResult { }
    public class Success : SayResult { }
    public class NoRecipientFound : SayResult { }
    public class RecipientOccupied : SayResult { }
    public class CommunicationProblem : SayResult { }

    public interface ISaySomething2
    {
        SayResult Say(string recipient, string content);
    }

    public class SaySomething2 : ISaySomething2
    {
        public SayResult Say(string recipient, string content)
        {
            return new CommunicationProblem();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ISaySomething service = new SaySomething();

            try
            {
                service.Say("", "");
            }
            catch (NoRecipientFoundException ex)
            {
                // do something
            }
            catch (RecipientOccupiedException ex)
            {
                // do something
            }
            catch (CommunicationProblemException ex)
            {
                // do something
            }

            //----------------------------------------------


            ISaySomething2 service2 = new SaySomething2();

            switch (service2.Say("", ""))
            {
                case Success res:
                    // do something
                    break;
                case NoRecipientFound res:
                    // do something
                    break;
                case RecipientOccupied res:
                    // do something
                    break;
                case CommunicationProblem res:
                    // do something
                    break;
            }
        }
    }
}