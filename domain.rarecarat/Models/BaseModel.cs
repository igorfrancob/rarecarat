﻿namespace domain.rarecarat.Models
{
	using System;

	public class BaseModel
	{
		public DateTime? CreatedAt { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public string UpdatedBy { get; set; }
	}
}
