using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;

namespace MedConnect
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
