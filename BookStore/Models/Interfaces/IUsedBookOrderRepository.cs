using BookStore.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Interfaces
{
	public interface IUsedBookOrderRepository
	{
		List<UsedBookOrderDto> Search(string status, string member);

		UsedBookOrderDto Get(int id);

		void UpdateStatus(int id, string status);

		List<UsedBookOrderDetailDto> SearchDetail(int id);

		List<UsedBooksLogisticsOrderDto> SearchLogisticsOrder(int id);


	}
}
