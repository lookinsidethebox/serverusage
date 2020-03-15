using System;
using System.ComponentModel.DataAnnotations;

namespace ServerUsage.Models
{
	public class ServerHistory
	{
		[Key]
		public int VirtualServerId { get; set; }

		public DateTime CreateDateTime { get; set; }

		public DateTime? RemoveDateTime { get; set; }
	}
}