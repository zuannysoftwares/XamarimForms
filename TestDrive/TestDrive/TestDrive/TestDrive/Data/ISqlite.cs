﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TestDrive.Data
{
    public interface ISqlite
    {
       SQLiteConnection RetornaConexao();
    }
}
