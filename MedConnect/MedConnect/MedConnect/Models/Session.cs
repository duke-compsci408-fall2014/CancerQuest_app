sing System;
using SQLite.Net.Attributes;

namespace MedConnect.Models
{
	public class Session
	{
        public Session()
        {
        }
        [PrimaryKey, AutoIncrement]
		public string session { get; set; }

	}
}

