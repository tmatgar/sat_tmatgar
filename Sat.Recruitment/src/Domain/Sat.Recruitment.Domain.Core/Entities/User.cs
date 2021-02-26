using System;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Domain.Core.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public string UserType { get; private set; }
        public decimal Money { get; private set; }

        public User(string name,
            string email,
            string address,
            string phone,
            string userType,
            decimal initialMoney)
        {
            WithName(name);
            WithEmail(email);
            WithAddress(address);
            WithPhone(phone);
            WithUserType(userType);
            WithInitialMoney(initialMoney);
        }
        public User(string fileLine)
        {
            WithName(fileLine.Split(',')[0].ToString());
            WithEmail(fileLine.Split(',')[1].ToString());
            WithAddress(fileLine.Split(',')[3].ToString());
            WithPhone(fileLine.Split(',')[2].ToString());
            WithUserType(fileLine.Split(',')[4].ToString());
            WithMoney(decimal.Parse(fileLine.Split(',')[5].ToString()));
        }

        private User WithName(string name)
        {
            Ensure.Argument.NotNullOrEmpty(name, nameof(name));
            Name = name;
            return this;
        }
        private User WithEmail(string email)
        {
            Ensure.Argument.NotNullOrEmpty(email, nameof(email));
            Email = email;
            return this;
        }
        private User WithAddress(string address)
        {
            Ensure.Argument.NotNullOrEmpty(address, nameof(address));
            Address = address;
            return this;
        }
        private User WithPhone(string phone)
        {
            Ensure.Argument.NotNullOrEmpty(phone, nameof(phone));
            Phone = phone;
            return this;
        }
        private User WithUserType(string userType)
        {
            Ensure.Argument.NotNullOrEmpty(userType, nameof(userType));
            UserType = userType;
            return this;
        }
        private User WithMoney(decimal money)
        {
            Ensure.Argument.Is(money >= 0, nameof(money));
            Money = money;
            return this;
        }
        private User WithInitialMoney(decimal initialMoney)
        {
            Ensure.Argument.Is(initialMoney >= 0, nameof(initialMoney));

            switch (UserType)
            {
                case "Normal":
                    if (initialMoney > 100)
                    {
                        var percentage = Convert.ToDecimal(0.12);
                        var gif = initialMoney * percentage;
                        Money = Money + gif;
                    }
                    else if (initialMoney < 100)
                    {
                        if (initialMoney > 10)
                        {
                            var percentage = Convert.ToDecimal(0.8);
                            var gif = initialMoney * percentage;
                            Money = Money + gif;
                        }
                    }
                    break;
                case "SuperUser":
                    if (initialMoney > 100)
                    {
                        var percentage = Convert.ToDecimal(0.20);
                        var gif = initialMoney * percentage;
                        Money = Money + gif;
                    }
                    break;
                case "Premium":
                    if (initialMoney > 100)
                    {
                        var gif = initialMoney * 2;
                        Money = Money + gif;
                    }
                    break;
                default:
                    break;
            }

            return this;
        }

        public bool CheckDuplicateUser(IEnumerable<User> list)
        {
            try
            {
                if (list.Any(x => x.Email == this.Email
                || x.Phone == this.Phone
                || (x.Name == this.Name && x.Address == this.Address)))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}