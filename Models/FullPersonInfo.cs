using System;

namespace Models
{
    public class FullPersonInfo
    {
        public Address Address { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public Person Person { get; set; }
        public PersonPhone PersonPhone { get; set; }

        public FullPersonInfo(Address address, Email email, Password password, Person person, PersonPhone personPhone)
        {
            Address = address;
            Email = email;
            Password = password;
            Person = person;
            PersonPhone = personPhone;
        }

        public FullPersonInfo()
        {

        }
    }
}
