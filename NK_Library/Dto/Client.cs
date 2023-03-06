using System;

namespace NK_Library.Dto
{
    internal class Client
    {
        public Client(string fullName, DateTime birthday, string phoneNumber)
        {
            FullName = fullName;
            Birthday = birthday;
            PhoneNumber = phoneNumber;
        }

        public string FullName { get; }

        public DateTime Birthday { get; }

        public string PhoneNumber { get; }

        #region Equals

        public static bool operator == (Client client1, Client client2)
        {
            if (Object.Equals(client1, null))
            {
                return Object.Equals(client2, null);
            }

            return client1.Equals(client2);
        }

        public static bool operator != (Client client1, Client client2)
        {
            return !(client1 == client2);
        }

        public override bool Equals(object obj)
        {
            var client = obj as Client;

            if (client != null)
            {
                return
                    client.FullName.Equals(FullName) &&
                    client.Birthday.Equals(Birthday) &&
                    client.PhoneNumber.Equals(PhoneNumber);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion Equals
    }
}
