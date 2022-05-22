using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Shop
{
	class Money
	{
		decimal money;
        public decimal MoneyCount { get => this.money; }

        public Money()
		{
			this.money = 0;
		}

		public void AddToMoney(decimal amount)
        {
			this.money += amount;
		}
	};
}
