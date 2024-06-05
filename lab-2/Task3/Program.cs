using System;

namespace SingletonPattern
{
    public sealed class Authenticator
    {
        private static Authenticator instance = null;
        
        private static readonly object lockObject = new object();
        
        private Authenticator()
        {
            Console.WriteLine("Створено екземпляр автентифікатора.");
        }

        public static Authenticator Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Authenticator();
                        }
                    }
                }
                return instance;
            }
        }

        public void Authenticate(string username, string password)
        {
            Console.WriteLine($"Автентифікація користувача {username}.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Authenticator auth1 = Authenticator.Instance;
            Authenticator auth2 = Authenticator.Instance;

            if (auth1 == auth2)
            {
                Console.WriteLine("Обидві автентифікації однакові.");
            }
            else
            {
                Console.WriteLine("Автентифікації різні.");
            }

            auth1.Authenticate("user1", "password1");
            auth2.Authenticate("user2", "password2");
        }
    }
}
