﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace OnBoarding
{
   public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
