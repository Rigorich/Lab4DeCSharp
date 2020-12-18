using System;
using System.Collections.Generic;
using DataAccessLayer;
using Models;

namespace ServiceLayer
{
    public class ServiceDAL
    {
        private readonly DataAccess DAL;

        public ServiceDAL(DataAccessLayer.Options.ConnectionOptions options)
        {
            DAL = new DataAccess(options);
        }

        public FullPersonInfo[] GetFullPersonInfo()
        {
            List<Address> addresses = DAL.GetListItems<Address>("GetAddress");
            List<Email> emails = DAL.GetListItems<Email>("GetEmail");
            List<Password> passwords = DAL.GetListItems<Password>("GetPassword");
            List<Person> persons = DAL.GetListItems<Person>("GetPerson");
            List<PersonPhone> personphones = DAL.GetListItems<PersonPhone>("GetPersonPhone");

            List<FullPersonInfo> infos = new List<FullPersonInfo>();
            for (int i = 0; i < persons.Count; i++)
            {
                infos.Add(new FullPersonInfo(addresses[i], emails[i], passwords[i], persons[i], personphones[i]));
            }
            return infos.ToArray();
        }
    }
}
