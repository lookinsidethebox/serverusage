using System;
using System.Collections.Generic;

namespace ServerUsage.Models
{
	public class IndexViewModel
	{
		public DateTime CurrentDateTime { get; set; }
		public string TotalUsageTime { get; set; }
		public List<ServerHistory> ServersHistory { get; set; }

		public IndexViewModel()
		{
			CurrentDateTime = DateTime.Now;
		}
	}
}